using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models
{
    public abstract class ListRequestBase : RequestBase
    {
        /// <summary>
        /// Pagination of the result.
        /// </summary>
        public ListRequestPagination Pagination { get; set; } = ListRequestPagination.TakeTen();

        /// <summary>
        /// Sorting of the result.
        /// </summary>
        public List<ListRequestSort> Sort { get; set; } = new List<ListRequestSort>();

        /// <summary>
        /// Filter of the result.
        /// </summary>
        public ListRequestFilter? Filter { get; set; } = null;
    }
}
