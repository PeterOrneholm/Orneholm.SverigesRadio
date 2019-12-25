using System;

namespace Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts
{
    public class ExtraBroadcast
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Sport { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime LocalStartTime { get; set; }
        public DateTime LocalStopTime { get; set; }
        public ExtraBroadcastPublisher Publisher { get; set; } = new ExtraBroadcastPublisher();
        public ExtraBroadcastChannel Channel { get; set; } = new ExtraBroadcastChannel();
        public ExtraBroadcastLiveAudio LiveAudio { get; set; } = new ExtraBroadcastLiveAudio();
        public ExtraBroadcastLiveAudio MobileliveAudio { get; set; } = new ExtraBroadcastLiveAudio();
    }
}
