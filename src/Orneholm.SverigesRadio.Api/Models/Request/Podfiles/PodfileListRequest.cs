using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Podfiles
{
    public class PodfileListRequest : ListRequestBase, IAudioSettings
    {
        public PodfileListRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; set; }

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
