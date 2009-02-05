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
using Estimator.Core;

namespace Estimator.Simple
{
    public class SimpleRuleRate : RuleRate
    {
        #region Fields
        private long rate_ = 1;
        private SimpleEstimationCategory category_ = null;
        private SimpleRuleIdentity identity_ = null;
        #endregion

        #region Constructors
        public SimpleRuleRate()
        {
        }
        #endregion

        #region RuleRate Members

        public EstimationCategory Category
        {
            get { return SimpleCategory; }
        }

        public SimpleEstimationCategory SimpleCategory
        {
            get { return category_; }
            set { category_ = value; }
        }

        public RuleIdentity RuleIdentity
        {
            get { return SimpleRuleIdentity; }
        }

        public SimpleRuleIdentity SimpleRuleIdentity
        {
            get { return identity_; }
            set { identity_ = value; }
        }

        public string RawData
        {
            get
            {
                return rate_.ToString();
            }

            set
            {
                if (value == null) return;

                long.TryParse(value, out rate_);
            }
        }
        #endregion

        #region Properties
        public long LongRate
        {
            get { return rate_; }
            set { rate_ = value; }
        }
        #endregion
    }
}
