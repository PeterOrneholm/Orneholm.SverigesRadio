using System;
using Orneholm.SverigesRadio.Api.Models.Request;

namespace Orneholm.SverigesRadio.Api.Models.Response
{
    public static class ListResponsePaginationExtensions
    {
        public static bool HasMoreContent(this ListResponsePagination listResponsePagination)
        {
            return listResponsePagination.CurrentPage < listResponsePagination.TotalPages;
        }

        public static ListPagination GetNextPageListPagination(this ListResponsePagination listResponsePagination)
        {
            if (!listResponsePagination.HasMoreContent())
            {
                throw new Exception("No more content available.");
            }

            return ListPagination.WithPageAndSize(listResponsePagination.CurrentPage + 1, listResponsePagination.CurrentPageSize);
        }
    }
}
