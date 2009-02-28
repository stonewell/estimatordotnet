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
    public class StockCategory : EstimationCategory
    {
        #region Fields
        private string stock_id_ = null;
        #endregion

        #region Constructors
        public StockCategory(string stock_id)
        {
            stock_id_ = stock_id;
        }
        #endregion

        #region Properties
        public string StockId
        {
            get { return stock_id_; }
        }
        #endregion

        #region Overloads
        public override bool Equals(object obj)
        {
            if (obj is StockCategory)
            {
                StockCategory tmp = obj as StockCategory;

                if (stock_id_ == null)
                    return tmp.stock_id_ == null;
            
                return stock_id_.Equals(tmp.stock_id_);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            if (stock_id_ != null)
                return stock_id_.GetHashCode();

            return base.GetHashCode();
        }

        public override string ToString()
        {
            if (stock_id_ != null)
                return stock_id_;

            return base.ToString();
        }
        #endregion
    }
}
