﻿//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
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
/// <summary>
/// Represents the widget object. </summary>
/// <seealso href="http://smartsheet-platform.github.io/api-docs/#celldataitem-object">CellDataItem Object Help</seealso>
    public class CellDataItem
    {
        /// <summary>
        /// Column ID for the cell
        /// </summary>
        private long? columnId;

        /// <summary>
        /// Row Id for each item
        /// </summary>
        private long? rowId;

        /// <summary>
        /// Sheet Id for each item
        /// </summary>
        private long? sheetId;

        /// <summary>
        /// The type of data returned will depend on the cell type and the data in the cell
        /// </summary>
        private object objectValue;

        /// <summary>
        /// Cell Object
        /// </summary>
        private Cell cell;

        /// <summary>
        /// CELL or SUMMARY_FIELD
        /// </summary>
        private string dataSource;

        /// <summary>
        /// Label for the data point. This will be either the column name or a user-provided string
        /// </summary>
        private string label;

        /// <summary>
        /// formatDescriptor
        /// </summary>
        private string labelFormat;

        /// <summary>
        /// The display order for the CellDataItem
        /// </summary>
        private int? order;

        /// <summary>
        /// SummaryField object if dataSource is SUMMARY_FIELD
        /// </summary>
        private SummaryField profileField;

        /// <summary>
        /// formatDescriptor
        /// </summary>
        private string valueFormat;

        /// <summary>
        /// Column Id for each item
        /// </summary>
        /// <returns>the column Id</returns>
        public long? ColumnId
        {
            get { return columnId; }
            set { columnId = value; }
        }

        /// <summary>
        /// Row Id for each item
        /// </summary>
        /// <returns>the row Id</returns>
        public long? RowId
        {
            get { return rowId; }
            set { rowId = value; }
        }

        /// <summary>
        /// Sheet Id for each item
        /// </summary>
        /// <returns>the sheet Id</returns>
        public long? SheetId
        {
            get { return sheetId; }
            set { sheetId = value; }
        }

        /// <summary>
        /// The type of data returned will depend on the cell type and the data in the cell.
        /// </summary>
        /// <returns> an object </returns>
        public object ObjectValue
        {
            get { return objectValue; }
            set { objectValue = value; }
        }

        /// <summary>
        /// Cell Object.
        /// </summary>
        /// <returns> the Cell Object </returns>
        public Cell Cell
        {
            get { return cell; }
            set { cell = value; }
        }

        /// <summary>
        /// CELL
        /// </summary>
        /// <returns>the dataSource string</returns>
        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        /// <summary>
        /// Label for the data point. This will be either the column name or a user-provided string.
        /// </summary>
        /// <returns> the label </returns>
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        /// <summary>
        /// formatDescriptor.
        /// </summary>
        /// <returns> the labelFormat </returns>
        public string LabelFormat
        {
            get { return labelFormat; }
            set { labelFormat = value; }
        }

        /// <summary>
        /// The display order for the CellDataItem.
        /// </summary>
        /// <returns> the display order </returns>
        public int? Order
        {
            get { return order; }
            set { order = value; }
        }

        /// <summary>
        /// Contains the SummaryField when dataSource is SUMMARY_FIELD
        /// </summary>
        /// <returns> SummaryField object </returns>
        public SummaryField ProfileField
        {
            get { return profileField; }
            set { profileField = value; }
        }

        /// <summary>
        /// formatDescriptor.
        /// </summary>
        /// <returns> the valueFormat </returns>
        public string ValueFormat
        {
            get { return valueFormat; }
            set { valueFormat = value; }
        }
    }
}
