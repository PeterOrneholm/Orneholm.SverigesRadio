using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Podfiles
{
    public class PodfileDetailsRequest : DetailsRequestBase, IAudioSettings
    {
        public PodfileDetailsRequest(int id)
        : base(id)
        {
        }

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
