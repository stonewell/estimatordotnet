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
using Estimator.Core.Impl;

namespace Estimator.Core.DB.Impl
{
    class MemoryDBManager : DBManager
    {
        #region Fields
        private EstimationEngine engine_ = null;
        private Dictionary<EstimationCategory, Dictionary<RuleIdentity, EstimationData>>
            database_ = new Dictionary<EstimationCategory, Dictionary<RuleIdentity, EstimationData>>();
        #endregion

        #region Constructors
        public MemoryDBManager(EstimationEngine engine)
        {
            engine_ = engine;
        }
        #endregion

        #region DBManager Members

        public EstimationEngine Engine
        {
            get { return engine_; }
        }

        public void Deinitialize()
        {
        }

        public void ClearResults(EstimationCategory category, RuleIdentity ruleId)
        {
        }

        public void UpdateRuleRate(RuleRate ruleRate)
        {
        }

        public EstimationResultList LoadResults(EstimationCategory category, RuleIdentity ruleId)
        {
            return new EstimationResultList();
        }

        public EstimationResult LoadLastResult(EstimationCategory category, RuleIdentity ruleId)
        {
            return null;
        }

        public void AddResult(EstimationResult result)
        {
        }

        public void Initialize()
        {
        }

        public EstimationData LoadEstimationData(EstimationCategory category, RuleIdentity ruleId)
        {
            if (database_.ContainsKey(category))
            {
                if (database_[category].ContainsKey(ruleId))
                {
                    return database_[category][ruleId];
                }
                else
                {
                    database_[category][ruleId] = new EstimationDataImpl(category, ruleId, null);
                }
            }
            else
            {
                database_[category] = new Dictionary<RuleIdentity, EstimationData>();
                database_[category][ruleId] = new EstimationDataImpl(category, ruleId, null);
            }

            return database_[category][ruleId];
        }

        #endregion
    }
}
