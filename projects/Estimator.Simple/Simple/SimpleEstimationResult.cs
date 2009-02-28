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
using Estimation.Core.Impl;
using Estimation.Core;

namespace Estimation.Simple
{
    public class SimpleEstimationResult : EstimationResult
    {
        #region Fields
        private SimpleEstimationCategory category_ = null;
        private SimpleRuleIdentity identity_ = null;
        private int value_ = 0;
        private bool goingUp_ = false; 
        #endregion

        #region Constructors
        public SimpleEstimationResult()
        {
        }
        #endregion

        #region EstimationResult Members

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
                return (value_ + "|" + goingUp_).ToString();
            }

            set
            {
                if (value == null) return;

                string[] parts = value.Split('|');

                if (parts.Length != 2) return;

                int.TryParse(parts[0],out value_);
                bool.TryParse(parts[1], out goingUp_);
            }
        }

        public bool ResultMatch(EstimationEvent e)
        {
            SimpleEstimationEvent simpleEvent = e as SimpleEstimationEvent;

            if (simpleEvent == null) return false;

            if (simpleEvent.Value >= value_ && goingUp_)
                return true;
            else if (simpleEvent.Value < value_ && !goingUp_)
                return true;

            return false;
        }
        #endregion

        #region Properties
        public int ResultValue
        {
            get { return value_; }
            set { value_ = value; }
        }

        public bool GoingUp
        {
            get { return goingUp_; }
            set { goingUp_ = value; }
        }
        #endregion
    }
}
