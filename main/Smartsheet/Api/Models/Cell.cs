//    #[license]
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

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the Cell object that holds data in a sheet.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Represents the column Id for this cell.
        /// </summary>
        private long? columnId;

        /// <summary>
        /// Represents the column Type.
        /// </summary>
        private ColumnType? columnType;

        /// <summary>
        /// The format descriptor describing this cell's conditional format. Only returned if the include query 
        /// string parameter contains format and this cell has a conditional format applied.
        /// </summary>
        private string conditionalFormat;

        /// <summary>
        /// Represents the display value.
        /// </summary>
        private string displayValue;

        /// <summary>
        /// The format descriptor. Only returned if the include query string parameter contains format and this cell 
        /// has a non-default format applied.
        /// </summary>
        private string format;

        /// <summary>
        /// The formula for the cell.
        /// </summary>
        private string formula;

        /// <summary>
        /// Represents a hyperlink to a URL, sheet, or report.
        /// </summary>
        private Hyperlink hyperlink;

        /// <summary>
        /// The image that the cell contains. Only returned if the cell contains an image
        /// </summary>
        private Image image;

        /// <summary>
        /// An inbound link from a cell in another sheet. This cell's value mirrors the linked cell's value
        /// </summary>
        private CellLink linkInFromCell;

        /// <summary>
        /// An array of CellLink objects. Zero or more outbound links from this cell to cells in other sheets 
        /// whose values mirror this cell's value
        /// </summary>
        private IList<CellLink> linksOutToCells;

        /// <summary>
        /// is an object representation of a cell's value and is currently used for adding or updating predecessor cell values
        /// </summary>
        ObjectValue objectValue;

        /// <summary>
        /// (Admin only) Indicates whether the cell value can contain a value outside of the validation limits (value = true). 
        /// When using this parameter, you must also set strict to false to bypass value type checking. This property is honored 
        /// for POST or PUT actions that update rows.
        /// </summary>
        private bool? overrideValidation;

        /// <summary>
        /// Represents the Strict flag.
        /// </summary>
        private bool? strict;

        /// <summary>
        /// Represents the value.
        /// </summary>
        private object value;

        /// <summary>
        /// Gets the column Id for this cell.
        /// </summary>
        /// <returns> the column Id </returns>
        public long? ColumnId
        {
            get { return columnId; }
            set { columnId = value; }
        }

        /// <summary>
        /// Gets the column Type.
        /// </summary>
        /// <returns> the Type </returns>
        public ColumnType? ColumnType
        {
            get { return columnType; }
            set { columnType = value; }
        }

        /// <summary>
        /// The format descriptor describing this cell's conditional format. Only returned if the include query string 
        /// parameter contains format and this cell has a conditional format applied.
        /// </summary>
        public string ConditionalFormat
        {
            get { return conditionalFormat; }
            set { conditionalFormat = value; }
        }

        /// <summary>
        /// Gets the display value used on special columns such as "Contact List".
        /// </summary>
        /// <returns> the display value </returns>
        public string DisplayValue
        {
            get { return displayValue; }
            set { displayValue = value; }
        }

        /// <summary>
        /// The format descriptor. Only returned if the include query string parameter contains format and this cell 
        /// has a non-default format applied.
        /// </summary>
        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        /// <summary>
        /// Gets the formula for this cell.
        /// </summary>
        /// <returns> the formula </returns>
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }

        /// <summary>
        /// A hyperlink to a URL, sheet, or report
        /// </summary>
        /// <returns> the link </returns>
        public Hyperlink Hyperlink
        {
            get { return hyperlink; }
            set { hyperlink = value; }
        }

        /// <summary>
        /// Gets the Strict value for this cell.
        /// </summary>
        /// <seealso href="http://www.Smartsheet.com/developers/Api-documentation#h.lay2yj3x1pp8">Column Types</seealso>
        /// <returns> the Strict </returns>
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// An inbound link from a cell in another sheet. This cell's value mirrors the linked cell's value.
        /// </summary>
        public CellLink LinkInFromCell
        {
            get { return linkInFromCell; }
            set { linkInFromCell = value; }
        }

        /// <summary>
        /// An array of CellLink objects. Zero or more outbound links from this cell to cells in other sheets 
        /// whose values mirror this cell's value.
        /// </summary>
        public IList<CellLink> LinksOutToCells
        {
            get { return linksOutToCells; }
            set { linksOutToCells = value; }
        }

        /// <summary>
        /// An object representation of a cell's value that is currently used for adding or updating predecessor cell values.
        /// </summary>
        /// <returns> the ObjectValue </returns>
        public ObjectValue ObjectValue
        {
            get { return objectValue; }
            set { objectValue = value;    }
        }

        /// <summary>
        /// (Admin only) Indicates whether the cell value can contain a value outside of the validation limits (value = true). 
        /// When using this parameter, you must also set strict to false to bypass value type checking. This property is 
        /// honored for POST or PUT actions that update rows.
        /// </summary>
        /// <returns> the override validation flag </returns>
        public bool? OverrideValidation
        {
            get { return overrideValidation; }
            set { overrideValidation = value; }
        }

        /// <summary>
        /// Gets the Strict value for this cell.
        /// </summary>
        /// <seealso href="http://www.Smartsheet.com/developers/Api-documentation#h.lay2yj3x1pp8">Column Types</seealso>
        /// <returns> the Strict </returns>
        public bool? Strict
        {
            get { return strict; }
            set { strict = value; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns> the value </returns>
        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// A convenience class for adding a cell with the necessary fields for inserting into a list of cells.
        /// </summary>
        public class AddCellBuilder
        {
            private long? columnId;

            private object value;

            private bool? strict;

            private string format;

            private Hyperlink hyperlink;

            /// <summary>
            /// Set required properties.
            /// </summary>
            /// <param name="columnId">the column Id</param>
            /// <param name="value">the value of the cell</param>
            public AddCellBuilder(long? columnId, object value)
            {
                this.columnId = columnId;
                this.value = value;
            }

            /// <summary>
            /// Sets the column Id
            /// </summary>
            /// <param name="columnId">the column Id</param>
            /// <returns>this AddCellBuilder</returns>
            public AddCellBuilder SetColumnId(long? columnId)
            {
                this.columnId = columnId;
                return this;
            }

            /// <summary>
            /// Sets the cell value
            /// </summary>
            /// <param name="value">the value</param>
            /// <returns>this AddCellBuilder</returns>
            public AddCellBuilder SetValue(object value)
            {
                this.value = value;
                return this;
            }

            /// <summary>
            /// Sets whether cells is Strict or not.
            /// </summary>
            /// <param name="strict">the Strict option</param>
            /// <returns>this AddCellBuilder</returns>
            public AddCellBuilder SetStrict(bool? strict)
            {
                this.strict = strict;
                return this;
            }

            /// <summary>
            /// Sets the format.
            /// </summary>
            /// <param name="format">the format</param>
            /// <returns>this AddCellBuilder</returns>
            public AddCellBuilder SetFormat(string format)
            {
                this.format = format;
                return this;
            }

            /// <summary>
            /// Sets the hyperlink.
            /// </summary>
            /// <param name="hyperlink">the hyperlink</param>
            /// <returns> this AddCellBuilder </returns>
            public AddCellBuilder SetHyperlink(Hyperlink hyperlink)
            {
                this.hyperlink = hyperlink;
                return this;
            }

            /// <summary>
            /// Gets the column Id.
            /// </summary>
            /// <returns>the column Id</returns>
            public long? GetColumnId()
            {
                return columnId;
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <returns>the value</returns>
            public object GetValue()
            {
                return value;
            }

            /// <summary>
            /// Gets the Strict option.
            /// </summary>
            /// <returns>the Strict option</returns>
            public bool? GetStrict()
            {
                return strict;
            }

            /// <summary>
            /// Gets the format.
            /// </summary>
            /// <returns>the format</returns>
            public string GetFormat()
            {
                return format;
            }

            /// <summary>
            /// Gets the hyperlink.
            /// </summary>
            /// <returns>the hyperlink</returns>
            public Hyperlink GetHyperlink()
            {
                return hyperlink;
            }

            /// <summary>
            /// Builds and returns the Cell object.
            /// </summary>
            /// <returns>Cell object</returns>
            public Cell Build()
            {
                Cell cell = new Cell();
                cell.ColumnId = columnId;
                cell.Value = value;
                cell.Strict = strict;
                cell.Format = format;
                cell.Hyperlink = hyperlink;
                return cell;
            }
        }

        /// <summary>
        /// A convenience class for updating a cell with the necessary fields for inserting into a list of cells.
        /// </summary>
        public class UpdateCellBuilder
        {
            private long? columnId;

            private object value;

            private bool? strict;

            private string format;

            private Hyperlink hyperlink;

            private CellLink linkInFromCell;

            /// <summary>
            /// Set required properties.
            /// </summary>
            /// <param name="columnId">required</param>
            /// <param name="value">required</param>
            public UpdateCellBuilder(long? columnId, object value)
            {
                this.columnId = columnId;
                this.value = value;
            }

            /// <summary>
            /// Sets the column Id
            /// </summary>
            /// <param name="columnId">columnId</param>
            /// <returns>this UpdateCellBuilder</returns>
            public UpdateCellBuilder SetColumnId(long? columnId)
            {
                this.columnId = columnId;
                return this;
            }

            /// <summary>
            /// Sets the value.
            /// </summary>
            /// <param name="value">(required)</param>
            /// <returns>this UpdateCellBuilder</returns>
            public UpdateCellBuilder SetValue(object value)
            {
                this.value = value;
                return this;
            }

            /// <summary>
            /// Sets the strict.
            /// </summary>
            /// <param name="strict">(optional)</param>
            /// <returns>this UpdateCellBuilder</returns>
            public UpdateCellBuilder SetStrict(bool? strict)
            {
                this.strict = strict;
                return this;
            }

            /// <summary>
            /// Sets the format.
            /// </summary>
            /// <param name="format">(optional)</param>
            /// <returns>this UpdateCellBuilder</returns>
            public UpdateCellBuilder SetFormat(string format)
            {
                this.format = format;
                return this;
            }

            /// <summary>
            /// (optional) with exactly one of the following attributes set:
            /// <list type="bullet">
            /// <item>url</item>
            /// <item>sheetId</item>
            /// <item>reportId</item>
            /// </list>
            /// </summary>
            /// <param name="hyperlink"> Link object </param>
            /// <returns> this UpdateCellBuilder </returns>
            public UpdateCellBuilder SetHyperlink(Hyperlink hyperlink)
            {
                this.hyperlink = hyperlink;
                return this;
            }

            /// <summary>
            /// (optional) with all of the following attributes set:
            /// <list type="bullet">
            /// <item>sheetId</item>
            /// <item>rowId</item>
            /// <item>columnId</item>
            /// </list>
            /// </summary>
            /// <param name="linkInFromCell"> CellLink object </param>
            /// <returns> this UpdateCellBuilder </returns>
            public UpdateCellBuilder SetLinkInFromCell(CellLink linkInFromCell)
            {
                this.linkInFromCell = linkInFromCell;
                return this;
            }

            /// <summary>
            /// Gets the column Id.
            /// </summary>
            /// <returns>the column Id.</returns>
            public long? GetColumnId()
            {
                return columnId;
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <returns>the value.</returns>
            public object GetValue()
            {
                return value;
            }

            /// <summary>
            /// Gets the Strict.
            /// </summary>
            /// <returns>
            /// the strict.
            /// </returns>
            public bool? GetStrict()
            {
                return strict;
            }

            /// <summary>
            /// Gets the format.
            /// </summary>
            /// <returns>the format</returns>
            public string GetFormat()
            {
                return format;
            }

            /// <summary>
            /// Gets the hyperLink
            /// </summary>
            /// <returns>the hyperlink</returns>
            public Hyperlink GetHyperlink()
            {
                return hyperlink;
            }

            /// <summary>
            /// Gets link in from cell.
            /// </summary>
            /// <returns>the link in from cell</returns>
            public CellLink GetLinkInFromCell()
            {
                return linkInFromCell;
            }

            /// <summary>
            /// Builds and returns the Cell object.
            /// </summary>
            /// <returns>Cell object</returns>
            public Cell Build()
            {
                Cell cell = new Cell();
                cell.ColumnId = columnId;
                cell.Value = value;
                cell.Strict = strict;
                cell.Format = format;
                cell.Hyperlink = hyperlink;
                cell.LinkInFromCell = linkInFromCell;
                return cell;
            }
        }
    }
}
