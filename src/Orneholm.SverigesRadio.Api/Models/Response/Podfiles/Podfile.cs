using System;
using System.Text.Json.Serialization;

namespace Orneholm.SverigesRadio.Api.Models.Response.Podfiles
{
    public class Podfile
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public PodfileProgram Program { get; set; } = new PodfileProgram();
        public DateTime AvailableFromUtc { get; set; }
        public DateTime PublishDateUtc { get; set; }

        public int FileSizeInBytes { get; set; }

        /// <summary>
        /// Ljudfilens längd (i sekunder)
        /// </summary>
        [JsonPropertyName("duration")]
        public int DurationInSeconds { get; set; }


        /// <summary>
        /// Används av Sveriges Radios applikationer.
        /// </summary>
        public string Statkey { get; set; } = string.Empty;


        public override string ToString() => $"Podfile: {Title} ({Id})";
    }
}
