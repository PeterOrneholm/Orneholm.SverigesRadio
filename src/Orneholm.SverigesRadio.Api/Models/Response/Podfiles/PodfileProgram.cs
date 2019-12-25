namespace Orneholm.SverigesRadio.Api.Models.Response.Podfiles
{
    public class PodfileProgram
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"PodfileProgram: {Name} ({Id})";
    }
}
