namespace Orneholm.SverigesRadio.Api.Models.Response.Channels
{
    public class ChannelDetailsResponse : DetailsResponseBase
    {
        public Channel Channel { get; set; } = new Channel();
    }
}