using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodePodfile
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public EpisodeProgram Program { get; set; } = new EpisodeProgram();
        public DateTime AvailableFromUtc { get; set; }
        public DateTime PublishDateUtc { get; set; }

        public int FileSizeInBytes { get; set; }

        /// <summary>
        /// Ljudfilens längd (i sekunder)
        /// </summary>
        public int Duration { get; set; }


        /// <summary>
        /// Används av Sveriges Radios applikationer.
        /// </summary>
        public string Statkey { get; set; } = string.Empty;
    }
}
