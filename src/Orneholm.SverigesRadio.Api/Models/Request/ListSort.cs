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
        /// Sortera på detta fält.
        /// </summary>
        public TField Field { get; set; }

        /// <summary>
        /// Sortera i fallande ordning.
        /// </summary>
        public bool SortDesc { get; set; }

        /// <summary>
        /// Sortera i stigande ordning,
        /// </summary>
        /// <param name="field">Fält att sortera på.</param>
        public static ListSort<TField> Asc(TField field)
        {
            return new ListSort<TField>(field, false);
        }

        /// <summary>
        /// Sortera i fallande ordning,
        /// </summary>
        /// <param name="field">Fält att sortera på.</param>
        public static ListSort<TField> Desc(TField field)
        {
            return new ListSort<TField>(field, true);
        }
    }
}
