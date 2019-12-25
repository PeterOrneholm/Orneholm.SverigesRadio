using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeNewsListResponse : ResponseBase
    {
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
