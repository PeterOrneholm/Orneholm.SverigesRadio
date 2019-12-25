namespace Orneholm.SverigesRadio.Api.Models.Response.ProgramCategories
{
    public class ProgramCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"ProgramCategory: {Name} ({Id})";
    }
}
