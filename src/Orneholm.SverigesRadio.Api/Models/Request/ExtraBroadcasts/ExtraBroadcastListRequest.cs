using System;
using System.Collections.Generic;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.ExtraBroadcasts
{
    public class ExtraBroadcastListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// Filtrera på detta datum.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Sorteringsordning
        /// </summary>
        public List<ListSort<ExtraBroadcastListSortFields>> Sort { get; set; } = new List<ListSort<ExtraBroadcastListSortFields>>();

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
