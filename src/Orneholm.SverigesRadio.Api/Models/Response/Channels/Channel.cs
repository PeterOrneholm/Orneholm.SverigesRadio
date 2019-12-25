using System.Text.Json.Serialization;

namespace Orneholm.SverigesRadio.Api.Models.Response.Channels
{
    public class Channel
    {
        /// <summary>
        /// Kanalens unika id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Kanalens namn.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// URL till kanalens bild.
        /// </summary>
        [JsonPropertyName("image")]
        public string ImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("imagetemplate")]
        public string ImageUrlTemplate { get; set; } = string.Empty;

        /// <summary>
        /// Kanalens färgkod (HEX).
        /// </summary>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Kanalens slogan.
        /// </summary>
        public string Tagline { get; set; } = string.Empty;

        /// <summary>
        /// URL till kanalens sida på sverigesradio.se
        /// </summary>
        public string SiteUrl { get; set; } = string.Empty;
        public string ScheduleUrl { get; set; } = string.Empty;

        /// <summary>
        /// Kanalens ljudström
        /// </summary>
        public ChannelLiveAudio LiveAudio { get; set; } = new ChannelLiveAudio();


        /// <summary>
        /// Kanalens kanaltyp. Beskriver vilken typ det är, t.ex. Rikskanal.
        /// </summary>
        public string ChannelType { get; set; } = string.Empty;

        /// <summary>
        /// Används av Sveriges Radios applikationer.
        /// </summary>
        public string XmlTvId { get; set; } = string.Empty;

        public override string ToString() => $"Channel: {Name} - {ChannelType} ({Id})";
    }
}
