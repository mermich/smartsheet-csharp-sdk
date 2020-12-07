﻿//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2019 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    public class MultiPicklistObjectValue : ObjectValue
    {
        public MultiPicklistObjectValue(IList<string> values)
        {
            this.values = values;
        }

        /// <summary>
        /// the list of selected options
        /// </summary>
        private IList<string> values;

        public ObjectValueType ObjectType
        {
            get { return ObjectValueType.MULTI_PICKLIST; }
        }

        /// <summary>
        /// Gets the array of Contact objects
        /// </summary>
        public IList<string> Values
        {
            get { return values; }
            set { values = value; }
        }
    }
}

