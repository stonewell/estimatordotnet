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
    public class StockRuleIdentity : RuleIdentity
    {
        #region Fields
        private string id_ = null;
        #endregion

        #region Constructors
        public StockRuleIdentity(string id)
        {
            id_ = id;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return id_; }
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return id_;
        }

        public override bool Equals(object obj)
        {
            if (obj is StockRuleIdentity)
            {
                StockRuleIdentity ruleId = obj as StockRuleIdentity;

                if (ruleId.id_ == null && id_ != null)
                    return false;

                if (ruleId.id_ != null && id_ == null)
                    return false;

                return ruleId.id_.Equals(id_);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            if (id_ == null)
                return base.GetHashCode();

            return id_.GetHashCode();
        }
        #endregion
    }
}
