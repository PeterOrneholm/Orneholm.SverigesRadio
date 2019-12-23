using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodePodfile
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public int FileSizeInBytes { get; set; }
        public EpisodeProgram Program { get; set; } = new EpisodeProgram();
        public DateTime AvailableFromUtc { get; set; }
        public int Duration { get; set; }
        public DateTime PublishDateUtc { get; set; }

        public string Statkey { get; set; } = string.Empty;
    }
}