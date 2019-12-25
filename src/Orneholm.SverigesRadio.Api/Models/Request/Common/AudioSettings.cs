namespace Orneholm.SverigesRadio.Api.Models.Request.Common
{
    public class AudioSettings
    {
        public AudioQuality? AudioQuality { get; set; } = null;
        public int? LiveAudioTemplateId { get; set; }
        public int? OnDemandAudioTemplateId { get; set; }
    }
}
