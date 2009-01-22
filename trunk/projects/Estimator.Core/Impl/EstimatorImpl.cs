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
        #region Inner Classes
        private class PushEventArgs
        {
            public PushEventArgs(EstimationContext c, EstimationEvent e)
            {
                Event = e;
                Context = c;
            }

            public EstimationEvent Event;
            public EstimationContext Context;
        }

        class RuleEventPusher
        {
            private EstimationRule rule_ = null;

            public RuleEventPusher(EstimationRule rule)
            {
                rule_ = rule;
            }

            public void OnPushEvnt(PushEventArgs args)
            {
                rule_.HandleEvent(new EstimationArguments(args.Event, args.Context));
            }
        }
        #endregion

        #region Delegates
        private delegate void PushEventHandler(PushEventArgs args);
        #endregion

        #region Events
        private event PushEventHandler OnPushEvent;
        #endregion

        #region Fields
        private EstimationRuleSet ruleSet_ = null;

        private EstimationContext context_ = null;
        #endregion

        #region Constructors
        public EstimatorImpl(EstimationRuleSet ruleSet)
        {
            ruleSet_ = ruleSet;

            HookEventHandler();
        }
        #endregion

        #region Estimator Members

        public EstimationRuleSet RuleSet
        {
            get { return ruleSet_; }
        }

        public bool PushEvent(EstimationEvent e)
        {
            if (OnPushEvent != null)
            {
                OnPushEvent.BeginInvoke(new PushEventArgs(context_, e), 
                    new AsyncCallback(OnPushEventCallBack), 
                    this);
            }

            return true;
        }

        public event EstimationResultEventHandler OnEstimationResult;

        #endregion

        #region Methods
        private void OnPushEventCallBack(IAsyncResult ar)
        {
            OnPushEvent.EndInvoke(ar);
        }

        private void UpdateEsitimationResult(EstimationResult result)
        {
            if (OnEstimationResult != null)
            {
                OnEstimationResult.BeginInvoke(new EstimationResultEventArgs(result),
                    new AsyncCallback(OnEstimationResultCallback),
                    this);
            }
        }

        private void OnEstimationResultCallback(IAsyncResult ar)
        {
            OnEstimationResult.EndInvoke(ar);
        }
        
        private void HookEventHandler()
        {
            foreach (EstimationRule rule in ruleSet_.Rules)
            {
                OnPushEvent += new PushEventHandler(new RuleEventPusher(rule).OnPushEvnt);
            }
        }
        #endregion
    }
}
