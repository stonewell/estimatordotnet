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
    public class SimpleEstimationCategory : EstimationCategory
    {
        #region Fields
        private const string id_ = "SimpleCategory";
        #endregion

        #region Constructors
        public SimpleEstimationCategory()
        {
        }
        #endregion

        #region Properties
        public string Id
        {
            get { return id_; }
        }
        #endregion

        #region Override
        public override bool Equals(object obj)
        {
            if (obj is SimpleEstimationCategory)
            {
                SimpleEstimationCategory category = obj as SimpleEstimationCategory;

                return string.Compare(category.Id, Id) == 0;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}
