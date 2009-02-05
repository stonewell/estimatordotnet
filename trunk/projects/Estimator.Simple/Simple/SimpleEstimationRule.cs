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

namespace Estimator.Simple
{
    public class SimpleEstimationRule : EstimationRule
    {
        #region Fields
        private SimpleRuleIdentity identity_ = null;
        private static readonly Random random_ = null;
        #endregion

        #region Constructors
        public SimpleEstimationRule(int id)
        {
            identity_ = new SimpleRuleIdentity(id);
        }

        static SimpleEstimationRule()
        {
            random_ = new Random(Convert.ToInt32(DateTime.Now.Ticks));
        }
        #endregion

        #region EstimationRule Members

        public RuleIdentity Identity
        {
            get { return SimpleRuleIdentity; }
        }

        public SimpleRuleIdentity SimpleRuleIdentity
        {
            get { return identity_; }
        }

        public virtual HandleEventResultEnum HandleEvent(EstimationArguments args)
        {
            EstimationContext context = args.Context;
            SimpleEstimationEvent e = args.Event as SimpleEstimationEvent;

            if (e == null)
            {
                return HandleEventResultEnum.InvalidEvent;
            }

            if (context == null)
            {
                return HandleEventResultEnum.InvalidContext;
            }

            EstimationData data = context.GetEstimationData(identity_);

            EstimationResult lastResult = data.LastResult;

            SimpleEstimationResult simpleLastResult = new SimpleEstimationResult();

            simpleLastResult.SimpleCategory = new SimpleEstimationCategory();
            simpleLastResult.SimpleRuleIdentity = SimpleRuleIdentity;

            SimpleRuleRate ruleRate = new SimpleRuleRate();
            ruleRate.SimpleRuleIdentity = SimpleRuleIdentity;
            ruleRate.SimpleCategory = new SimpleEstimationCategory();

            if (data.RuleRate != null)
            {
                ruleRate.RawData = data.RuleRate.RawData;
            }

            if (lastResult != null)
            {
                //check with current event and update rate
                simpleLastResult.RawData = lastResult.RawData;

                if (simpleLastResult.ResultMatch(e))
                {
                    ruleRate.LongRate++;
                }
                else
                {
                    ruleRate.LongRate--;
                }
            }

            data.UpdateRuleRate(ruleRate);

            simpleLastResult.ResultValue = e.Value;
            simpleLastResult.GoingUp = random_.Next(0, 100) > 50;

            data.AddResult(simpleLastResult);

            return HandleEventResultEnum.OK;
        }

        #endregion
    }
}
