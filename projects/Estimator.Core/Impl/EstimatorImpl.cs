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
    class EstimatorImpl : EstimationBaseObj, Estimator
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
        #endregion

        #region Fields
        private EstimationRuleSet ruleSet_ = null;
        private EstimationCategory category_ = null;

        private EstimationContext context_ = null;
        private List<PushEventHandler> pushEventHandlerList_ = new List<PushEventHandler>();
        #endregion

        #region Constructors
        public EstimatorImpl(EstimationCategory category, EstimationRuleSet ruleSet)
        {
            ruleSet_ = ruleSet;
            category_ = category;

            OnEngineChangedEvent += new EngineChangedHandler(EstimatorImpl_OnEngineChangedEvent);

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
            //foreach(PushEventHandler handler in pushEventHandlerList_)
            //{
            //    handler.BeginInvoke(new PushEventArgs(context_, e), 
            //        (OnPushEventCallBack),
            //        handler);
            //}

            foreach (EstimationRule rule in ruleSet_.Rules)
            {
                rule.HandleEvent(new EstimationArguments(e, context_));
            }

            return true;
        }

        public event AddResultHandler OnAddEstimationResult;
        public event RemoveResultHandler OnRemoveEstimationResult;
        public event UpdateRuleRateHandler OnRuleRateUpdate;

        #endregion

        #region Methods
        private void OnPushEventCallBack(IAsyncResult ar)
        {
            PushEventHandler d = ar.AsyncState as PushEventHandler;
            d.EndInvoke(ar);
        }
      
        private void HookEventHandler()
        {
            foreach (EstimationRule rule in ruleSet_.Rules)
            {
                pushEventHandlerList_.Add(new PushEventHandler(new RuleEventPusher(rule).OnPushEvnt));
            }
        }
        
        private void EstimatorImpl_OnEngineChangedEvent(EstimationEngine oldEngine, EstimationEngine newEngine)
        {
            if (context_ != null)
            {
                context_.Deinitialize(this);
                context_ = null;
            }

            context_ = Engine.CreateContext(category_);
            context_.Initialize(this);

            context_.OnAddEstimationResult += new AddResultHandler(context__OnAddEstimationResult);
            context_.OnRemoveEstimationResult += new RemoveResultHandler(context__OnRemoveEstimationResult);
            context_.OnRuleRateUpdate += new UpdateRuleRateHandler(context__OnRuleRateUpdate);
        }

        private void context__OnRuleRateUpdate(UpdateRuleRateEventArgs args)
        {
            if (OnRuleRateUpdate != null)
            {
                OnRuleRateUpdate.BeginInvoke(args,
                    (OnRuleRateUpdateCallback),
                    OnRuleRateUpdate);
            }
        }

        private void OnRuleRateUpdateCallback(IAsyncResult ar)
        {
            UpdateRuleRateHandler d = ar.AsyncState as UpdateRuleRateHandler;
            d.EndInvoke(ar);
        }

        private void context__OnRemoveEstimationResult(EstimationResultEventArgs args)
        {
            if (OnRemoveEstimationResult != null)
            {
                OnRemoveEstimationResult.BeginInvoke(args,
                    (OnRemoveEstimationResultCallback),
                    OnRemoveEstimationResult);
            }
        }

        private void OnRemoveEstimationResultCallback(IAsyncResult ar)
        {
            RemoveResultHandler d = ar.AsyncState as RemoveResultHandler;
            d.EndInvoke(ar);
        }

        private void context__OnAddEstimationResult(EstimationResultEventArgs args)
        {
            if (OnAddEstimationResult != null)
            {
                OnAddEstimationResult.BeginInvoke(args,
                    (OnAddEstimationResultCallback),
                    OnAddEstimationResult);
            }
        }

        private void OnAddEstimationResultCallback(IAsyncResult ar)
        {
            AddResultHandler d = ar.AsyncState as AddResultHandler;
            d.EndInvoke(ar);
        }

        public void Initialize()
        {
        }

        public void Deinitialize()
        {
            if (context_ != null)
            {
                context_.Deinitialize(this);
            }
        }
        #endregion
    }
}
