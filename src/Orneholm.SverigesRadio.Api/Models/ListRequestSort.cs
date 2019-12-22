namespace Orneholm.SverigesRadio.Api.Models
{
    public class ListRequestSort
    {
        private ListRequestSort(string field, bool sortDesc)
        {
            Field = field;
            SortDesc = sortDesc;
        }

        /// <summary>
        /// Field to sort by.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Sort in descending order.
        /// </summary>
        public bool SortDesc { get; set; }

        public static ListRequestSort Asc(string field)
        {
            return new ListRequestSort(field, false);
        }

        public static ListRequestSort Desc(string field)
        {
            return new ListRequestSort(field, true);
        }
    }
}
