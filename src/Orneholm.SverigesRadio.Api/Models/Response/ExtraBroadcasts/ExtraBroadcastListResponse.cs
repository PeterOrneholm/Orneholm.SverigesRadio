using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts
{
    public class ExtraBroadcastListResponse : ListResponseBase
    {
        public List<ExtraBroadcast> Broadcasts { get; set; } = new List<ExtraBroadcast>();
    }
}
