using System;
using Orneholm.SverigesRadio.Api.Models.Request.Common;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeListRequest : ListRequestBase, IAudioSettings
    {
        public EpisodeListRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
