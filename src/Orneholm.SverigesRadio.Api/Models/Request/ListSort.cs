namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public class ListSort
    {
        private ListSort(string field, bool sortDesc)
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

        public static ListSort Asc(string field)
        {
            return new ListSort(field, false);
        }

        public static ListSort Desc(string field)
        {
            return new ListSort(field, true);
        }
    }
}
