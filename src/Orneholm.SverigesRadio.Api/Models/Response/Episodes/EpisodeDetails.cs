using System;
using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeDetails : Episode
    {
        public string Text { get; set; } = string.Empty;
        public List<EpisodeGroup> EpisodeGroups { get; set; } = new List<EpisodeGroup>();
    }
}
