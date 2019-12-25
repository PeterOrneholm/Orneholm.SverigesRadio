using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.Broadcasts
{
    public class BroadcastExtra
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Sport { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime LocalStartTime { get; set; }
        public DateTime LocalStopTime { get; set; }
        public BroadcastExtraPublisher BroadcastPublisher { get; set; } = new BroadcastExtraPublisher();
        public BroadcastExtraChannel Channel { get; set; } = new BroadcastExtraChannel();
        public BroadcastExtraLiveAudio LiveAudio { get; set; } = new BroadcastExtraLiveAudio();
        public BroadcastExtraLiveAudio MobileliveAudio { get; set; } = new BroadcastExtraLiveAudio();
    }

    public class BroadcastExtraPublisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BroadcastExtraChannel
    {
        public int Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class BroadcastExtraLiveAudio
    {
        public int Id { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Statkey { get; set; } = string.Empty;
    }

}
