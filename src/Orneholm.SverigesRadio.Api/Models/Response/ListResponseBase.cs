namespace Orneholm.SverigesRadio.Api.Models.Response
{
    public abstract class ListResponseBase : ResponseBase
    {
        public ListResponsePagination Pagination { get; set; } = new ListResponsePagination();
    }
}
