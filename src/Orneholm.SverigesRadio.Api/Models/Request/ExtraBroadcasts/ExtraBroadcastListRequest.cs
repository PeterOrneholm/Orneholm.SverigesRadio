using System;
using System.Collections.Generic;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.ExtraBroadcasts
{
    public class ExtraBroadcastListRequest : ListRequestBase, IHasAudioSettings
    {
        public DateTime? Date { get; set; }

        public List<ListSort<ExtraBroadcastListSortFields>> Sort { get; set; } = new List<ListSort<ExtraBroadcastListSortFields>>();

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
