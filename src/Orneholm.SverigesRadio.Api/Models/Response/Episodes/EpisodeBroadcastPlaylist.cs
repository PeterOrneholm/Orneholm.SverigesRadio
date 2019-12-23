using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeBroadcastPlaylist
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        public int Duration { get; set; }
        public DateTime PublishDateUtc { get; set; }

        public string Statkey { get; set; } = string.Empty;
    }
}