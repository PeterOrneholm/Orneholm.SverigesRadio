using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeListResponse : ListResponseBase
    {
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
