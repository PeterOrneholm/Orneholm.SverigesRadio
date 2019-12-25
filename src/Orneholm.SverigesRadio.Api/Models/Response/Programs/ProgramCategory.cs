namespace Orneholm.SverigesRadio.Api.Models.Response.Programs
{
    public class ProgramCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"ProgramCategory: {Name} ({Id})";
    }
}
