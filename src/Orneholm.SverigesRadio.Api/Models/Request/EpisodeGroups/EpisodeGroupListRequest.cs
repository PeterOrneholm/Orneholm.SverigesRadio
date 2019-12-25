using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups
{
    public class EpisodeGroupListRequest : ListRequestBase, IHasAudioSettings
    {
        public EpisodeGroupListRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
