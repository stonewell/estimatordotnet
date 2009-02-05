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
    class EstimationContextImpl : EstimationBaseObj, EstimationContext
    {
        #region Event
        public event AddResultHandler OnAddEstimationResult;
        public event RemoveResultHandler OnRemoveEstimationResult;
        public event UpdateRuleRateHandler OnRuleRateUpdate;
        #endregion

        #region Fields
        private EstimationCategory category_ = null;
        #endregion

        #region Constructors
        public EstimationContextImpl(EstimationCategory category)
        {
            category_ = category;
        }
        #endregion

        #region EstimationContext Members

        public EstimationData GetEstimationData(RuleIdentity ruleId)
        {
            EstimationData data =
                Engine.DatabaseManager.LoadEstimationData(category_, ruleId);

            data.OnAddResult -= new AddResultHandler(data_OnAddResult);
            data.OnRemoveResult -= new RemoveResultHandler(data_OnRemoveResult);
            data.OnRuleRateUpdate -= new UpdateRuleRateHandler(data_OnRuleRateUpdate);

            data.OnAddResult += new AddResultHandler(data_OnAddResult);
            data.OnRemoveResult += new RemoveResultHandler(data_OnRemoveResult);
            data.OnRuleRateUpdate += new UpdateRuleRateHandler(data_OnRuleRateUpdate);

            return data;
        }

        private void data_OnRuleRateUpdate(UpdateRuleRateEventArgs args)
        {
            if (OnRuleRateUpdate != null)
            {
                OnRuleRateUpdate.BeginInvoke(args,
                    new AsyncCallback(OnRuleRateUpdateCallback),
                    this);
            }
        }

        private void OnRuleRateUpdateCallback(IAsyncResult ar)
        {
            OnRuleRateUpdate.EndInvoke(ar);
        }

        private void data_OnRemoveResult(EstimationResultEventArgs args)
        {
            if (OnRemoveEstimationResult != null)
            {
                OnRemoveEstimationResult.BeginInvoke(args,
                    new AsyncCallback(OnRemoveEstimationResultCallback),
                    this);
            }
        }

        private void OnRemoveEstimationResultCallback(IAsyncResult ar)
        {
            OnRemoveEstimationResult.EndInvoke(ar);
        }

        private void data_OnAddResult(EstimationResultEventArgs args)
        {
            if (OnAddEstimationResult != null)
            {
                OnAddEstimationResult.BeginInvoke(args,
                    new AsyncCallback(OnAddEstimationResultCallback),
                    this);
            }
        }

        private void OnAddEstimationResultCallback(IAsyncResult ar)
        {
            OnAddEstimationResult.EndInvoke(ar);
        }

        #endregion
    }
}
