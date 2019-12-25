using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeLatestDetailsRequest : RequestBase, IHasAudioSettings
    {
        public EpisodeLatestDetailsRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}