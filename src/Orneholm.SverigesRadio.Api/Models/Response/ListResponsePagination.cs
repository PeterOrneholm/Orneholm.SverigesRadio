using System.Text.Json.Serialization;

namespace Orneholm.SverigesRadio.Api.Models.Response
{
    public class ListResponsePagination
    {
        [JsonPropertyName("page")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("size")]
        public int CurrentPageSize { get; set; }
        public int TotalHits { get; set; }
        public int TotalPages { get; set; }
    }
}
