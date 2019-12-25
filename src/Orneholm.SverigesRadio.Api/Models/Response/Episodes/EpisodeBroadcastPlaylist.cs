using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeBroadcastPlaylist
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Ljudfilens längd (i sekunder)
        /// </summary>
        public int Duration { get; set; }
        public DateTime PublishDateUtc { get; set; }

        /// <summary>
        /// Används av Sveriges Radios applikationer.
        /// </summary>
        public string Statkey { get; set; } = string.Empty;

        public override string ToString() => $"EpisodeBroadcastPlaylist: {Url} ({Id})";
    }
}
