namespace Orneholm.SverigesRadio.Api.Models.Response
{
    public abstract class ListResponseBase : ResponseBase
    {
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
