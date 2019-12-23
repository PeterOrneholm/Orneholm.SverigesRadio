namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public class ListFilter
    {
        public ListFilter(string field, string value)
        {
            Field = field;
            Value = value;
        }

        /// <summary>
        /// Field to filter.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Value to filter by.
        /// </summary>
        public string Value { get; set; }
    }
}
