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
    public abstract class StockRule : EstimationRule
    {
        #region Fields
        private StockRuleIdentity identity_ = null;
        private bool detectUp_ = false;
        #endregion

        #region Constructors
        public StockRule(string rulename, bool detectUp)
        {
            identity_ = new StockRuleIdentity(rulename);
            detectUp_ = detectUp;
        }
        #endregion

        #region EstimationRule Members

        public RuleIdentity Identity
        {
            get { return StockRuleIdentity; }
        }

        public StockRuleIdentity StockRuleIdentity
        {
            get { return identity_; }
        }

        public HandleEventResultEnum HandleEvent(EstimationArguments args)
        {
            if (!(args.Event is StockEvent))
                return HandleEventResultEnum.InvalidEvent;

            bool ruleRateUpdated = false;

            StockEvent stockEvent = args.Event as StockEvent;

            //Console.Error.WriteLine("0.{0} Handle Event", stockEvent.EventDateTime);

            EstimationContext context = args.Context;

            EstimationData data = context.GetEstimationData(identity_);

            StockRuleRate rate = new StockRuleRate();
            rate.StockRuleIdentity = identity_;
            rate.StockCategory = stockEvent.StockCategory;

            if (data.RuleRate != null)
            {
                rate.RawData = data.RuleRate.RawData;
            }

            rate.StockRateUpdateDate = stockEvent.EventDateTime;

            if (data.LastResult != null)
            {
                if (MatchResult(stockEvent, data.LastResult))
                {
                    rate.SuccessCount++;
                }
                else
                {
                    rate.FailCount++;
                }

                if (!ruleRateUpdated)
                {
                    data.UpdateRuleRate(rate);
                    Console.Error.WriteLine("1.{0} Update Rule Rate", stockEvent.EventDateTime);

                    ruleRateUpdated = true;
                }
            }

            StockEstimationResult result = null;

            if (TryGenerateResult(stockEvent, data, out result))
            {
                data.AddResult(result);

                if (!ruleRateUpdated)
                {
                    data.UpdateRuleRate(rate);

                    Console.Error.WriteLine("2.{0} Update Rule Rate", stockEvent.EventDateTime);
                    ruleRateUpdated = true;
                }
            }
            else
            {
                data.AddResult(null);
            }

            return HandleEventResultEnum.OK;
        }

        #endregion

        #region Methods
        public bool IsDetectUpRule
        {
            get { return detectUp_; }
        }

        virtual protected bool MatchResult(StockEvent stockEvent, EstimationResult result)
        {
            StockEstimationResult stockResult = new StockEstimationResult();
            stockResult.RawData = result.RawData;

            bool match = false;

            if (stockResult.GoingUpRate > 0 && stockEvent.Final > stockResult.StockEvent.Final)
                match = true;

            if (stockResult.GoingDownRate > 0 && stockEvent.Final < stockResult.StockEvent.Final)
                match = true;

            if (stockResult.GoingDownRate == 0 &&
                stockResult.GoingUpRate == 0 &&
                stockEvent.Final == stockResult.StockEvent.Final)
            {
                match = true;
            }

            if (stockResult.PriceRangeSet)
            {
                if (stockEvent.Final >= stockResult.MinPrice &&
                    stockEvent.Final <= stockResult.MaxPrice)
                {
                    match = true;
                }
            }
            return match;
        }

        abstract protected bool TryGenerateResult(StockEvent stockEvnt, EstimationData data, out StockEstimationResult result);
        #endregion
    }
}
