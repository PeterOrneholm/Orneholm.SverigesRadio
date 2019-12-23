using System;

namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public class ListSort<TField> where TField : Enum
    {
        private ListSort(TField field, bool sortDesc)
        {
            Field = field;
            SortDesc = sortDesc;
        }

        /// <summary>
        /// Field to sort by.
        /// </summary>
        public TField Field { get; set; }

        /// <summary>
        /// Sort in descending order.
        /// </summary>
        public bool SortDesc { get; set; }

        public static ListSort<TField> Asc(TField field)
        {
            return new ListSort<TField>(field, false);
        }

        public static ListSort<TField> Desc(TField field)
        {
            return new ListSort<TField>(field, true);
        }
    }
}
