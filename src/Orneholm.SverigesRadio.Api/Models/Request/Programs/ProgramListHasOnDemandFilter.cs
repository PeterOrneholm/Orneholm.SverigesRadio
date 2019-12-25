namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public class ProgramListHasOnDemandFilter : ProgramListFilter
    {
        private readonly bool _hasOnDemand;

        public ProgramListHasOnDemandFilter(bool hasOnDemand)
            : base(Constants.Programs.Filter.HasOnDemand)
        {
            _hasOnDemand = hasOnDemand;
        }

        public override string GetFilterValue()
        {
            return _hasOnDemand ? Constants.Common.QueryString.True : Constants.Common.QueryString.False;
        }
    }
}