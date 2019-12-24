using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Broadcasts
{
    public class BroadcastListResponse : ListResponseBase
    {
        public List<Broadcast> Broadcasts { get; set; } = new List<Broadcast>();
    }
}
