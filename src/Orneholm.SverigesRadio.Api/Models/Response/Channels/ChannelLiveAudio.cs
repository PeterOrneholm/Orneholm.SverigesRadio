namespace Orneholm.SverigesRadio.Api.Models.Response.Channels
{
    public class ChannelLiveAudio
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Används av Sveriges Radios applikationer.
        /// </summary>
        public string StatKey { get; set; } = string.Empty;

        public override string ToString() => $"ChannelLiveAudio: {Url} ({Id})";
    }
}
