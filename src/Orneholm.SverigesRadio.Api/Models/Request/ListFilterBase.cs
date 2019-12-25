namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public abstract class ListFilterBase
    {
        private readonly string _filterField;

        protected ListFilterBase(string filterField)
        {
            _filterField = filterField;
        }

        public string GetFilterField()
        {
            return _filterField;
        }

        public abstract string GetFilterValue();
    }
}
