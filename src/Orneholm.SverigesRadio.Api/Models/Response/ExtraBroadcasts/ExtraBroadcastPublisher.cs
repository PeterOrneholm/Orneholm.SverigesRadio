namespace Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts
{
    public class ExtraBroadcastPublisher
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"ExtraBroadcastPublisher: {Name} ({Id})";
    }
}
