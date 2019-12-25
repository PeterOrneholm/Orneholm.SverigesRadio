using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeLatestDetailsRequest : RequestBase, IAudioSettings
    {
        public EpisodeLatestDetailsRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; }

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
