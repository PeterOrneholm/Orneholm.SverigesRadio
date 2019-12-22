using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models
{
    public class ProgramListResponse : ListResponseBase
    {
        public List<Program> Programs { get; set; } = new List<Program>();
    }
}
