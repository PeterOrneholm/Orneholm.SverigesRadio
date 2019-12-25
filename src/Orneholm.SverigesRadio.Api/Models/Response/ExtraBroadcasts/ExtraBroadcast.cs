using System;
using System.Text.Json.Serialization;

namespace Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts
{
    public class ExtraBroadcast
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("sport")]
        public bool IsSport { get; set; }

        public DateTime LocalStartTime { get; set; }
        public DateTime LocalStopTime { get; set; }

        public ExtraBroadcastPublisher Publisher { get; set; } = new ExtraBroadcastPublisher();
        public ExtraBroadcastChannel Channel { get; set; } = new ExtraBroadcastChannel();
        public ExtraBroadcastLiveAudio LiveAudio { get; set; } = new ExtraBroadcastLiveAudio();
        public ExtraBroadcastLiveAudio MobileLiveAudio { get; set; } = new ExtraBroadcastLiveAudio();

        public override string ToString() => $"ExtraBroadcast: {Name} ({Id})";
    }
}
