using System;
using System.Collections.Generic;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Broadcasts
{
    public class BroadcastListExtraRequest : ListRequestBase, IHasAudioSettings
    {
        public DateTime? Date { get; set; }

        public List<ListSort<BroadcastListExtraSortFields>> Sort { get; set; } = new List<ListSort<BroadcastListExtraSortFields>>();

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
