using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.ProgramCategories
{
    public class ProgramCategoryListResponse : ListResponseBase
    {
        public List<ProgramCategory> ProgramCategories { get; set; } = new List<ProgramCategory>();
    }
}
