namespace Orneholm.SverigesRadio.Api.Models.Response
{
    public abstract class ListResponseBase : ResponseBase
    {
        public ListPagination Pagination { get; set; } = new ListPagination();
    }
}
