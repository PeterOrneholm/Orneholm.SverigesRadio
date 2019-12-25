using System.Collections.Generic;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeDetailsMultipleRequest : ListRequestBase, IHasAudioSettings
    {
        public EpisodeDetailsMultipleRequest(List<int> ids)
        {
            Ids = ids;
        }

        public List<int> Ids { get; set; }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
