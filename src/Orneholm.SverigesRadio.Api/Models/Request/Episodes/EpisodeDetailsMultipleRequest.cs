using System.Collections.Generic;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeDetailsMultipleRequest : ListRequestBase, IHasAudioSettings
    {
        /// <param name="ids">Avsnitts idn</param>
        public EpisodeDetailsMultipleRequest(List<int> ids)
        {
            Ids = ids;
        }

        /// <summary>
        /// Avsnitts idn
        /// </summary>
        public List<int> Ids { get; set; }

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
