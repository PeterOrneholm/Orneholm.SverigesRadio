using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime PublishDateUtc { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
        public string ImageUrlTemplate { get; set; } = string.Empty;

        public EpisodeProgram Program { get; set; } = new EpisodeProgram();

        public string AudioPreference { get; set; } = string.Empty;
        public string AudioPriority { get; set; } = string.Empty;
        public string AudioPresentation { get; set; } = string.Empty;

        public EpisodePodfile? ListenPodfile { get; set; }
        public EpisodePodfile? DownloadPodfile { get; set; }
        public EpisodeBroadcast? Broadcast { get; set; }
    }
}
