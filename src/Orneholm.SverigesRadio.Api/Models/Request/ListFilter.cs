using System;

namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public class ListFilter<TField> where TField : Enum
    {
        public ListFilter(TField field, string value)
        {
            Field = field;
            Value = value;
        }

        /// <summary>
        /// Field to filter.
        /// </summary>
        public TField Field { get; set; }

        /// <summary>
        /// Value to filter by.
        /// </summary>
        public string Value { get; set; }
    }
}
