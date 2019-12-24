using System;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Broadcasts
{
    public class BroadcastListRequest : ListRequestBase, IAudioSettings
    {
        public BroadcastListRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; set; }

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
