namespace Orneholm.SverigesRadio.Api.Models.Response.Channels
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
        public string ImageTemplate { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public string SiteUrl { get; set; } = string.Empty;
        public ChannelLiveAudio LiveAudio { get; set; } = new ChannelLiveAudio();
        public string ScheduleUrl { get; set; } = string.Empty;
        public string ChannelType { get; set; } = string.Empty;
        public string XmlTvId { get; set; } = string.Empty;
    }
}
