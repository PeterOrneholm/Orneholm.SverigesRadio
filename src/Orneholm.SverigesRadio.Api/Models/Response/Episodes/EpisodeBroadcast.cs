using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeBroadcast
    {
        public DateTime AvailableStopUtc { get; set; }
        public EpisodeBroadcastPlaylist Playlist { get; set; } = new EpisodeBroadcastPlaylist();
        public EpisodeBroadcastFile[] BroadcastFiles { get; set; } = {};
    }
}
