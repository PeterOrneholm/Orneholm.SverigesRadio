namespace Orneholm.SverigesRadio.Api.Models.Response.EpisodeGroups
{
    public class EpisodeGroupListResponse : ListResponseBase
    {
        public EpisodeGroup EpisodeGroup { get; set; } = new EpisodeGroup();
    }
}
