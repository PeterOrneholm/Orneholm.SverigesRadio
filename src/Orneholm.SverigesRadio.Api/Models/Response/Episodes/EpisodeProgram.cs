namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeProgram
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"EpisodeProgram: {Name} ({Id})";
    }
}
