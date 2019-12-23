namespace Orneholm.SverigesRadio.Api.Models.Response.Episodes
{
    public class EpisodeDetailsResponse : DetailsResponseBase
    {
        public Episode Episode { get; set; } = new Episode();
    }
}
