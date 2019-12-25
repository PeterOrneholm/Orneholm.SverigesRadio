using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeNewsListRequest : RequestBase, IHasAudioSettings
    {
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
