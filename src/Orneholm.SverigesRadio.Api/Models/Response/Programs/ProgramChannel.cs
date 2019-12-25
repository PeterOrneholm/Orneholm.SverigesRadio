namespace Orneholm.SverigesRadio.Api.Models.Response.Programs
{
    public class ProgramChannel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"ProgramChannel: {Name} ({Id})";
    }
}
