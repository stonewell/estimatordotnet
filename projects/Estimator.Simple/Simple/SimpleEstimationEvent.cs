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
using Estimation.Core;

namespace Estimation.Simple
{
    public class SimpleEstimationEvent : EstimationEvent
    {
        #region Fields
        private SimpleEstimationCategory category_ = null;
        private int value_ = 0;
        #endregion

        #region EstimationEvent Members

        public EstimationCategory Category
        {
            get { return SimpleCategory; }
        }

        public SimpleEstimationCategory SimpleCategory
        {
            get { return category_; }
            set { category_ = value; }
        }
        #endregion

        #region Properties
        public int Value
        {
            get { return value_; }
            set { value_ = value; }
        }
        #endregion
    }
}
