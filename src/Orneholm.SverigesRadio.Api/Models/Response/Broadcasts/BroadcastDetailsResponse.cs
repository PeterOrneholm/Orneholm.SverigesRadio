namespace Orneholm.SverigesRadio.Api.Models.Response.Broadcasts
{
    public class BroadcastDetailsResponse : DetailsResponseBase
    {
        public Broadcast Broadcast { get; set; } = new Broadcast();
    }
}
