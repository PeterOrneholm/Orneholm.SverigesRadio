namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public class ProgramListHasPodFilter : ProgramListFilter
    {
        private readonly bool _hasPod;

        public ProgramListHasPodFilter(bool hasPod)
            : base(Constants.Programs.Filter.HasPod)
        {
            _hasPod = hasPod;
        }

        public override string GetFilterValue()
        {
            return _hasPod ? Constants.Common.QueryString.True : Constants.Common.QueryString.False;
        }
    }
}