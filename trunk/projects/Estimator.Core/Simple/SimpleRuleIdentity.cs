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

namespace Estimator.Core.Simple
{
    public class SimpleRuleIdentity : RuleIdentity
    {
        #region Fields
        private int id_ = 0;
        #endregion

        #region Constructors
        public SimpleRuleIdentity(int id)
        {
            id_ = id;
        }
        #endregion

        #region Properties
        public int IntId
        {
            get { return id_; }
        }
        #endregion

        #region Override
        public override bool Equals(object obj)
        {
            if (obj is SimpleRuleIdentity)
            {
                SimpleRuleIdentity ruleId = obj as SimpleRuleIdentity;

                return ruleId.id_ == id_;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return id_.GetHashCode();
        }
        #endregion
    }
}
