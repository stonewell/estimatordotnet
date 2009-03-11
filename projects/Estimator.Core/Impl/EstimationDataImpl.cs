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
    class EstimationDataImpl : EstimationBaseObj, EstimationData
    {
        #region Fields
        private EstimationCategory category_ = null;
        private RuleIdentity ruleId_ = null;
        private RuleRate ruleRate_ = null;

        private EstimationResult lastResult_ = null;

        private object locker_ = new object();

        private EstimationObjectMap objects_ = new EstimationObjectMap();

        private bool eventHandlerSet_ = false;
        #endregion

        #region Constructors
        public EstimationDataImpl(EstimationCategory category,
            RuleIdentity ruleId,
            RuleRate ruleRate)
        {
            category_ = category;
            ruleId_ = ruleId;
            ruleRate_ = ruleRate;
        }
        #endregion

        #region EstimationData Members

        public event AddResultHandler OnAddResult;

        public event RemoveResultHandler OnRemoveResult;

        public event UpdateRuleRateHandler OnRuleRateUpdate;

        public EstimationCategory Category
        {
            get { return category_; }
        }

        public RuleIdentity RuleIdentity
        {
            get { return ruleId_; }
        }

        public RuleRate RuleRate
        {
            get { return ruleRate_; }
        }

        public EstimationResult LastResult
        {
            get 
            {
                if (lastResult_ == null)
                {
                    LoadLastResult();
                }

                return lastResult_;
            }
        }

        public void AddResult(EstimationResult result)
        {
            lock (locker_)
            {
                EstimationResult oldLastResult = lastResult_;

                lastResult_ = result;

                Engine.DatabaseManager.AddResult(result);

                if (OnAddResult != null)
                {
                    OnAddResult.BeginInvoke(new EstimationResultEventArgs(result),
                        (OnAddResultCallback),
                        OnAddResult);
                }
            }
        }

        private void OnAddResultCallback(IAsyncResult ar)
        {
            AddResultHandler impl = ar.AsyncState as AddResultHandler;

            impl.EndInvoke(ar);
        }

        private void OnRuleRateUpdateCallback(IAsyncResult ar)
        {
            UpdateRuleRateHandler impl = ar.AsyncState as UpdateRuleRateHandler;
            impl.EndInvoke(ar);
        }

        public void ClearResult()
        {
            lock (locker_)
            {
                foreach(EstimationResult result in AllResults)
                {
                    if (OnRemoveResult != null)
                    {
                        OnRemoveResult.BeginInvoke(new EstimationResultEventArgs(result),
                            (OnRemoveResultCallback),
                            OnRemoveResult);
                    }
                }

                Engine.DatabaseManager.ClearResults(category_, ruleId_);
            }
        }

        private void OnRemoveResultCallback(IAsyncResult ar)
        {
            RemoveResultHandler impl = ar.AsyncState as RemoveResultHandler;

            impl.EndInvoke(ar);
        }

        public EstimationResultList AllResults
        {
            get 
            { 
                return Engine.DatabaseManager.LoadResults(category_, ruleId_); 
            }
        }

        public void UpdateRuleRate(RuleRate ruleRate)
        {
            lock (locker_)
            {
                bool rateUpdated = true;
                RuleRate oldRate = ruleRate_;
                ruleRate_ = ruleRate;

                if (rateUpdated && OnRuleRateUpdate != null)
                {
                    Engine.DatabaseManager.UpdateRuleRate(ruleRate_);

                    OnRuleRateUpdate.BeginInvoke(new UpdateRuleRateEventArgs(oldRate, ruleRate_),
                        (OnRuleRateUpdateCallback),
                        OnRuleRateUpdate);
                }
            }
        }

        public EstimationObjectMap Objects
        {
            get { return objects_; }
        }

        public bool EventHandlerSet
        {
            get { return eventHandlerSet_; }
            set { eventHandlerSet_ = value; }
        }
        #endregion

        #region Methods
        private void LoadLastResult()
        {
            lock (locker_)
            {
                lastResult_ = Engine.DatabaseManager.LoadLastResult(category_, ruleId_);
            }
        }
        #endregion
    }
}
