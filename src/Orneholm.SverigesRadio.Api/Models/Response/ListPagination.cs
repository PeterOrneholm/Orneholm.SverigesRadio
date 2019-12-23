namespace Orneholm.SverigesRadio.Api.Models.Response
{
    public class ListPagination
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalHits { get; set; }
        public int TotalPages { get; set; }
        public string? NextPage { get; set; }
    }
}
