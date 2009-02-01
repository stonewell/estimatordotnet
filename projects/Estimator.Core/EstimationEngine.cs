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
using Estimator.Core.Impl;

namespace Estimator.Core
{
    public sealed class EstimationEngine
    {
        #region Fields
        private readonly DB.DBManager dbManager_ = null;
        #endregion

        #region Constructors
        public EstimationEngine()
        {
            dbManager_ = new DB.DBManager(this);
        }
        #endregion

        #region Properties
        internal DB.DBManager DatabaseManager { get { return dbManager_; } }
        #endregion

        #region Methods
        public void Initialize()
        {
            dbManager_.Initialize();
        }

        public void Deinitialize()
        {
            dbManager_.Deinitialize();
        }

        public Estimator CreateEstimator(EstimationCategory category, EstimationRuleSet ruleSet)
        {
            Estimator estimator = new EstimatorImpl(category, ruleSet);

            UpdateEstimationObjProperties(estimator);

            return estimator;
        }

        private void UpdateEstimationObjProperties(object obj)
        {
            if (obj is EstimationBaseObj)
            {
                EstimationBaseObj baseObj = obj as EstimationBaseObj;

                baseObj.Engine = this;
            }
        }

        internal EstimationContext CreateContext(EstimationCategory category)
        {
            EstimationContext context = new EstimationContextImpl(category);

            UpdateEstimationObjProperties(context);

            return context;
        }

        #endregion
    }
}
