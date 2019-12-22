namespace Orneholm.SverigesRadio.Api.Models
{
    public abstract class ListResponseBase : ResponseBase
    {
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
