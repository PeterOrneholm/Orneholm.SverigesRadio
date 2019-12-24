using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Podfiles
{
    public class PodfileListResponse : ListResponseBase
    {
        public List<Podfile> Podfiles { get; set; } = new List<Podfile>();
    }
}
