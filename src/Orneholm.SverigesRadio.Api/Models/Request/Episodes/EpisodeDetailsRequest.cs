using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeDetailsRequest : DetailsRequestBase, IHasAudioSettings
    {
        public EpisodeDetailsRequest(int id)
        : base(id)
        {
        }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
