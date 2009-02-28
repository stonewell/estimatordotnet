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
    public class StockEvent : EstimationEvent
    {
        #region Fields
        private StockCategory category_ = null;
        private double lowest_ = 0.0f;
        private double highest_ = 0.0f;
        private double final_ = 0.0f;
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
        #endregion
    }
}
