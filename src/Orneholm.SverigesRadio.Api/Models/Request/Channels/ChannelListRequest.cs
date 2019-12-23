namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public class ChannelListRequest : ListRequestBase, IAudioSettings
    {
        /// <summary>
        /// Filter of the result.
        /// </summary>
        public ListFilter<ChannelListFilterFields>? Filter { get; set; } = null;

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
