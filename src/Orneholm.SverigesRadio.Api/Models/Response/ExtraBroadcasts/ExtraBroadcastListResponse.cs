using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Broadcasts
{
    public class ExtraBroadcastListResponse : ListResponseBase
    {
        public List<Broadcast> Broadcasts { get; set; } = new List<Broadcast>();
    }
}
