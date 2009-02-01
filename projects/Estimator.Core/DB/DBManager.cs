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

namespace Estimator.Core.DB
{
    class DBManager
    {
        #region Fields
        private EstimationEngine engine_ = null;
        #endregion

        #region Constructors
        public DBManager(EstimationEngine engine)
        {
            engine_ = engine;
        }
        #endregion

        #region Methods
        public void Initialize()
        {
        }

        public EstimationData LoadEstimationData(EstimationCategory category,
            RuleIdentity ruleId)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        internal void Deinitialize()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal void ClearResults(EstimationCategory category_, RuleIdentity ruleId_)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal void UpdateRuleRate(RuleRate ruleRate_)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal EstimationResultList LoadResults(EstimationCategory category_, RuleIdentity ruleId_)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal EstimationResult LoadLastResult(EstimationCategory category_, RuleIdentity ruleId_)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal void AddResult(EstimationResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
