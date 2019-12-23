using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Programs
{
    public class ProgramListResponse : ListResponseBase
    {
        public List<Program> Programs { get; set; } = new List<Program>();
    }
}
