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
    public class StockEstimationResult : EstimationResult
    {
        #region Fields
        private StockCategory category_ = null;
        private StockRuleIdentity identity_ = null;

        private StockEvent event_ = null;

        private long goingUpRate_ = 0;
        private long goingDownRate_ = 0;

        private bool priceRangeSet_ = false;
        private double maxPrice_ = 0.0f;
        private double minPrice_ = 0.0f;
        #endregion

        #region EstimationResult Members

        public EstimationCategory Category
        {
            get { return StockCategory; }
        }

        public StockCategory StockCategory
        {
            get { return category_; }
        }

        public RuleIdentity RuleIdentity
        {
            get { return StockRuleIdentity; }
        }

        public StockRuleIdentity StockRuleIdentity
        {
            get { return identity_; }
        }

        public string RawData
        {
            get
            {
                if (event_ == null)
                    throw new ApplicationException("Invalid StockEvent");

                StringBuilder sb = new StringBuilder();

                sb.Append(event_.RawData).Append(";");
                sb.Append(goingDownRate_).Append("|");
                sb.Append(goingUpRate_).Append("|");
                sb.Append(priceRangeSet_).Append("|");
                sb.Append(maxPrice_).Append("|");
                sb.Append(minPrice_);

                return sb.ToString();
            }
         
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);

                string[] parts = value.Split(';');

                if (parts.Length < 2)
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);

                event_ = new StockEvent();
                event_.RawData = parts[0];

                parts = parts[1].Split('|');

                if (parts.Length < 5)
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);

                if (!long.TryParse(parts[0], out goingDownRate_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
                if (!long.TryParse(parts[1], out goingUpRate_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);

                if (!bool.TryParse(parts[2], out priceRangeSet_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
                if (!double.TryParse(parts[3], out maxPrice_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
                if (!double.TryParse(parts[4], out minPrice_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
            }
        }

        #endregion

        #region Properties
        public long GoingUpRate
        {
            get { return goingUpRate_; }
            set { goingUpRate_ = value; }
        }

        public long GoingDownRate
        {
            get { return goingDownRate_; }
            set { goingDownRate_ = value; }
        }

        public bool PriceRangeSet
        {
            get { return priceRangeSet_; }
        }

        public double MaxPrice
        {
            get { return maxPrice_; }
        }

        public double MinPrice
        {
            get { return minPrice_; }
        }

        public StockEvent StockEvent
        {
            get { return event_; }
            set { event_ = value; }
        }
        #endregion

        #region Methods
        public void SetPriceRange(double max, double min)
        {
            maxPrice_ = max;
            minPrice_ = min;
            priceRangeSet_ = true;
        }

        public void ClearPriceRange()
        {
            priceRangeSet_ = false;
        }
        #endregion
    }
}
