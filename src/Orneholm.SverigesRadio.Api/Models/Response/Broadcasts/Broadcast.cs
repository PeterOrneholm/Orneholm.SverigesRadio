using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Broadcasts
{
    public class Broadcast
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BroadcastDateUtc { get; set; }
        public int TotalDuration { get; set; }

        public string Image { get; set; } = string.Empty;
        public string ImageTemplate { get; set; } = string.Empty;

        public DateTime AvailableStopUtc { get; set; }
        public BroadcastPlaylist Playlist { get; set; } = new BroadcastPlaylist();
        public BroadcastFile[] BroadcastFiles { get; set; } = {};
    }
}
