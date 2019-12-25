using System;
using System.Text.Json.Serialization;

namespace Orneholm.SverigesRadio.Api.Models.Response.Broadcasts
{
    public class Broadcast
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime BroadcastDateUtc { get; set; }
        public DateTime AvailableStopUtc { get; set; }

        /// <summary>
        /// Sändningens längd i sekunder.
        /// </summary>
        [JsonPropertyName("totalduration")]
        public int TotalDurationInSeconds { get; set; }

        /// <summary>
        /// URL till sändningens bild.
        /// </summary>
        [JsonPropertyName("image")]
        public string ImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("imagetemplate")]
        public string ImageUrlTemplate { get; set; } = string.Empty;


        public BroadcastPlaylist Playlist { get; set; } = new BroadcastPlaylist();
        public BroadcastFile[] BroadcastFiles { get; set; } = {};

        public override string ToString() => $"Broadcast: {Title} ({Id})";
    }
}
