namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public abstract class ProgramListFilter : ListFilterBase
    {
        protected ProgramListFilter(string filterField)
            : base(filterField)
        {
            
        }
    }
}