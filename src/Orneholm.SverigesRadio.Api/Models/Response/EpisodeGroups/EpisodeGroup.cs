using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.EpisodeGroups
{
    public class EpisodeGroup
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<EpisodeGroupEpisode> Episodes { get; set; } = new List<EpisodeGroupEpisode>();

        public override string ToString() => $"EpisodeGroup: {Title} ({Id})";
    }
}
