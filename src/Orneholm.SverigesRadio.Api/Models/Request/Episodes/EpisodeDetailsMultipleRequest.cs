using System.Collections.Generic;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeDetailsMultipleRequest : ListRequestBase, IAudioSettings
    {
        public EpisodeDetailsMultipleRequest(List<int> ids)
        {
            Ids = ids;
        }

        public List<int> Ids { get; set; }

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
