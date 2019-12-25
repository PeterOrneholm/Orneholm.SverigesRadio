namespace Orneholm.SverigesRadio.Api.Models.Response
{
    public class ListResponsePagination
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalHits { get; set; }
        public int TotalPages { get; set; }
    }
}
