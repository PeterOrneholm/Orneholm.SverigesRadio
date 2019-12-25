using System;
using System.Text.Json.Serialization;

namespace Orneholm.SverigesRadio.Api.Models.Response.Broadcasts
{
    public class BroadcastFile
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Ljudfilens längd (i sekunder)
        /// </summary>
        [JsonPropertyName("duration")]
        public int DurationInSeconds { get; set; }
        public DateTime PublishDateUtc { get; set; }

        /// <summary>
        /// Används av Sveriges Radios applikationer.
        /// </summary>
        public string Statkey { get; set; } = string.Empty;

        public override string ToString() => $"BroadcastFile: {Url} ({Id})";
    }
}
