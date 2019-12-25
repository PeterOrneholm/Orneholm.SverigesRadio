namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public class ProgramListResponsibleEditorFilter : ProgramListFilter
    {
        private readonly string _responsibleEditor;

        public ProgramListResponsibleEditorFilter(string responsibleEditor)
            : base(Constants.Programs.Filter.ResponsibleEditor)
        {
            _responsibleEditor = responsibleEditor;
        }

        public override string GetFilterValue()
        {
            return _responsibleEditor;
        }
    }
}