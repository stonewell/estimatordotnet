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

namespace Estimation.Core
{
    public interface EstimationObject
    {
        string RawData { get; set; }
    }

    public class EstimationObjectMap : Dictionary<string, EstimationObject>
    {
    }

    public class EstimationIntObject : EstimationObject
    {
        #region Fields
        private int value_ = 0;
        #endregion

        #region Constructors
        public EstimationIntObject()
        {
        }

        public EstimationIntObject(int val)
        {
            value_ = val;
        }
        #endregion

        #region EstimationObject Members

        public string RawData
        {
            get
            {
                return value_.ToString();
            }
            set
            {
                int.TryParse(value, out value_);
            }
        }

        #endregion

        #region Properties
        public int IntValue
        {
            get { return value_; }
            set { value_ = value; }
        }
        #endregion
    }
}
