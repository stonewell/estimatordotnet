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

namespace Estimation.Core
{
    public class EstimationResultEventArgs
    {
        private EstimationResult result_ = null;

        public EstimationResultEventArgs(EstimationResult result)
        {
            result_ = result;
        }

        public EstimationResult Result { get { return result_; } }
    }

    public class UpdateRuleRateEventArgs
    {
        private RuleRate oldRate_ = null;
        private RuleRate newRate_ = null;

        public UpdateRuleRateEventArgs(RuleRate oldRate, RuleRate newRate)
        {
            oldRate_ = oldRate;
            newRate_ = newRate;
        }

        public RuleRate OldRate { get { return oldRate_; } }
        public RuleRate NewRate { get { return newRate_; } }
    }

    public delegate void AddResultHandler(EstimationResultEventArgs args);
    public delegate void RemoveResultHandler(EstimationResultEventArgs args);
    public delegate void UpdateRuleRateHandler(UpdateRuleRateEventArgs args);

    public interface EstimationData
    {
        event AddResultHandler OnAddResult;
        event RemoveResultHandler OnRemoveResult;
        event UpdateRuleRateHandler OnRuleRateUpdate;

        EstimationCategory Category { get; }
        RuleIdentity RuleIdentity { get; }

        RuleRate RuleRate { get; }
        void UpdateRuleRate(RuleRate ruleRate);

        EstimationResult LastResult { get; }

        void AddResult(EstimationResult result);
        void ClearResult();

        EstimationResultList AllResults { get; }

        EstimationObjectMap Objects { get; }

        bool EventHandlerSet { get; set; }
    }
}
