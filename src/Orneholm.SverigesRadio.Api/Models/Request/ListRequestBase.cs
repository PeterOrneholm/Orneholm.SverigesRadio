using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public abstract class ListRequestBase : RequestBase
    {
        /// <summary>
        /// Pagination of the result.
        /// </summary>
        public ListPagination Pagination { get; set; } = ListPagination.FirstPage();

        /// <summary>
        /// Sorting of the result.
        /// </summary>
        public List<ListSort> Sort { get; set; } = new List<ListSort>();

        /// <summary>
        /// Filter of the result.
        /// </summary>
        public ListFilter? Filter { get; set; } = null;
    }
}
