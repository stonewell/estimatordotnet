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

namespace Stock.Estimator.Rules
{
    public class ThreeBlackCrows : StockRule
    {
        public ThreeBlackCrows()
            : base("ThreeBlackCrows", false)
        {
        }

        protected override bool TryGenerateResult(StockEvent stockEvnt,
            Estimation.Core.EstimationData data,
            out StockEstimationResult result)
        {
            StockEvent lastEvent = null;
            int count = 0;
            result = null;

            if (data.Objects.ContainsKey("LastEvent"))
                lastEvent = data.Objects["LastEvent"] as StockEvent;

            if (data.Objects.ContainsKey("Count"))
                count = (data.Objects["Count"] as EstimationIntObject).IntValue;

            if (count < 0)
                throw new Exception("Invalid state, count < 0");

            if (count > 0 && lastEvent == null)
            {
                throw new Exception("Invalid State,LastEvent is null but count=" + count);
            }

            bool valid = stockEvnt.IsYin;

            bool resultGenerated = false;

            if (lastEvent != null)
                valid = valid & stockEvnt.Final < lastEvent.Final;

            if (valid)
            {
                count++;

                if (count == 3)
                {
                    result = new StockEstimationResult();
                    result.GoingUpRate = 0;
                    result.GoingDownRate = 100;
                    result.StockRuleIdentity = StockRuleIdentity;
                    result.StockCategory = stockEvnt.StockCategory;
                    result.ClearPriceRange();
                    result.StockEvent = stockEvnt;
                    count = 0;
                    resultGenerated = true;
                }

                data.Objects["LastEvent"] = stockEvnt;
                data.Objects["Count"] = new EstimationIntObject(count);
            }
            else
            {
                data.Objects.Remove("LastEvent");
                data.Objects.Remove("Count");
            }

            return resultGenerated;
        }
    }
}
