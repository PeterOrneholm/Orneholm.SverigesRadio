namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public class ProgramListArchiveFilter : ProgramListFilter
    {
        private readonly bool _archived;

        public ProgramListArchiveFilter(bool archived)
            : base(Constants.Programs.Filter.Archived)
        {
            _archived = archived;
        }

        public override string GetFilterValue()
        {
            return _archived ? Constants.Common.QueryString.True : Constants.Common.QueryString.False;
        }
    }
}