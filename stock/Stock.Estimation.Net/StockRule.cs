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

namespace Stock.Estimator
{
    public class StockRule : EstimationRule
    {
        #region Fields
        private StockRuleIdentity identity_ = null;
        #endregion

        #region Constructors
        public StockRule(string rulename)
        {
            identity_ = new StockRuleIdentity(rulename);
        }
        #endregion

        #region EstimationRule Members

        public RuleIdentity Identity
        {
            get { return identity_; }
        }

        public HandleEventResultEnum HandleEvent(EstimationArguments args)
        {
            if (!(args.Event is StockEvent))
                return HandleEventResultEnum.InvalidEvent;

            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
