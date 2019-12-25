namespace Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts
{
    public class ExtraBroadcastLiveAudio
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Statkey { get; set; } = string.Empty;
    }
}