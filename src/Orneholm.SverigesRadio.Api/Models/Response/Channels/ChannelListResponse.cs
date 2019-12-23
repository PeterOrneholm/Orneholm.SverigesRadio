using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Channels
{
    public class ChannelListResponse : ListResponseBase
    {
        public List<Channel> Channels { get; set; } = new List<Channel>();
    }
}