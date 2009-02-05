#region File Header
/**
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
 * License for the specific language governing rights and limitations
 * under the License.
 * 
 * Code Author: jingnan.si@gmail.com
 */
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Estimation.Core.Impl
{
    delegate void EngineChangedHandler(EstimationEngine oldEngine, EstimationEngine newEngine);

    class EstimationBaseObj
    {
        protected event EngineChangedHandler OnEngineChangedEvent;

        private EstimationEngine engine_ = null;

        public EstimationEngine Engine
        {
            get { return engine_; }

            set 
            {
                EstimationEngine oldEngine = engine_;
                engine_ = value;

                if (OnEngineChangedEvent != null)
                {
                    OnEngineChangedEvent(oldEngine, engine_);
                }
            }
        }
    }
}
