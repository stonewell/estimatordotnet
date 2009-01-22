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

namespace Estimator.Core.Impl
{
    class EstimatorImpl : Estimator
    {
        #region Fields
        private EstimationRuleSet ruleSet_ = null;
        #endregion

        #region Constructors
        public EstimatorImpl(EstimationRuleSet ruleSet)
        {
            ruleSet_ = ruleSet;
        }
        #endregion

        #region Estimator Members

        public EstimationRuleSet RuleSet
        {
            get { return ruleSet_; }
        }

        public bool PushEvent(EstimationEvent e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public event EstimationResultsEventHandler OnEstimationResults;

        #endregion
    }
}
