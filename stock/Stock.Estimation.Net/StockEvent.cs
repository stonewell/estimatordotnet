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
    public class StockEvent : EstimationEvent, EstimationObject
    {
        #region Fields
        private StockCategory category_ = null;
 
        private double lowest_ = 0.0f;
        private double highest_ = 0.0f;
        private double final_ = 0.0f;
        private double begin_ = 0.0f;
        #endregion

        #region EstimationEvent Members

        public EstimationCategory Category
        {
            get { return StockCategory; }
        }

        public StockCategory StockCategory
        {
            get { return category_; }
            set { category_ = value; }
        }
        #endregion

        #region Properties
        public double Lowest
        {
            get { return lowest_; }
            set { lowest_ = value; }
        }

        public double Highest
        {
            get { return highest_; }
            set { highest_ = value; }
        }

        public double Final
        {
            get { return final_; }
            set { final_ = value; }
        }

        public double Begin
        {
            get { return begin_; }
            set { begin_ = value; }
        }
        #endregion

        #region EstimationObject Members

        public string RawData
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(highest_).Append("|");
                sb.Append(lowest_).Append("|");
                sb.Append(final_).Append("|");
                sb.Append(begin_);

                return sb.ToString();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ApplicationException("Invalid raw data for StockEvent:" + value);

                string[] parts = value.Split('|');

                if (parts.Length < 4)
                    throw new ApplicationException("Invalid raw data for StockEvent:" + value);

                if (!double.TryParse(parts[0], out highest_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
                if (!double.TryParse(parts[1], out lowest_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
                if (!double.TryParse(parts[2], out final_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
                if (!double.TryParse(parts[2], out begin_))
                    throw new ApplicationException("Invalid raw data for StockEstimationResult:" + value);
            }
        }

        #endregion

        #region Properties
        public bool IsYang
        {
            get { return final_ > begin_; }
        }

        public bool IsYin
        {
            get { return final_ < begin_; }
        }

        public bool WithUpShadow
        {
            get { return highest_ > final_ && highest_ > begin_; }
        }

        public bool WithDownShadow
        {
            get { return lowest_ < final_ && lowest_ < begin_; }
        }

        public bool CrossStar
        {
            get { return final_ == begin_ && WithDownShadow && WithUpShadow; }
        }

        public bool T
        {
            get { return final_ == begin_ && WithDownShadow && !WithUpShadow; }
        }

        public bool AntiT
        {
            get { return final_ == begin_ && !WithDownShadow && WithUpShadow; }
        }
        #endregion
    }
}
