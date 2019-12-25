namespace Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts
{
    public class ExtraBroadcastChannel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"ExtraBroadcastChannel: {Name} ({Id})";
    }
}
