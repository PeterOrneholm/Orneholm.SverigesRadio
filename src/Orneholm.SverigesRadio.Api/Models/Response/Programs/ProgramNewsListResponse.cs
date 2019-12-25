using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.Programs
{
    public class ProgramNewsListResponse : ResponseBase
    {
        public List<Program> Programs { get; set; } = new List<Program>();
    }
}
