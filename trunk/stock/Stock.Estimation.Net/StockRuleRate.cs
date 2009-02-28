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
    public class StockRuleRate : RuleRate
    {
        #region Fields
        private StockCategory category_ = null;
        private StockRuleIdentity identity_ = null;

        private long successCount_ = 0;
        private long failCount_ = 0;
        #endregion

		#region Constructors
		public StockRuleRate()
		{
		}
		#endregion
		
        #region RuleRate Members

        public EstimationCategory Category
        {
            get { return StockCategory; }
        }

        public StockCategory StockCategory
        {
            get { return category_; }
            set { category_ = value; }
        }

        public RuleIdentity RuleIdentity
        {
            get { return StockRuleIdentity; }
        }

        public StockRuleIdentity StockRuleIdentity
        {
            get { return identity_; }
            set { identity_ = value; }
        }

        public string RawData
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(successCount_).Append("|").Append(failCount_);

                return sb.ToString();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Invalid raw data for StockRuleRate:" + value);
                }
                else
                {
                    string[] parts = value.Split('|');

                    if (parts.Length < 2)
                    {
                        throw new ApplicationException("Invalid raw data for StockRuleRate:" + value);
                    }
                    else
                    {
                        successCount_ = 0;
                        failCount_ = 0;

                        if (!long.TryParse(parts[0], out successCount_))
                            throw new ApplicationException("Invalid raw data for StockRuleRate:" + value);

                        if (!long.TryParse(parts[1], out failCount_))
                            throw new ApplicationException("Invalid raw data for StockRuleRate:" + value);
                    }
                }

            }
        }
        #endregion

        #region Properties
        public long SuccessCount
        {
            get { return successCount_; }
            set { successCount_ = value; }
        }

        public long FailCount
        {
            get { return failCount_; }
            set { failCount_ = value; }
        }
        #endregion
    }
}
