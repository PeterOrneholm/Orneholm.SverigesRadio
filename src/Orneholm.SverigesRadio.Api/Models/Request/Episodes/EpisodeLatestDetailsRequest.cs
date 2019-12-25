using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeLatestDetailsRequest : RequestBase, IHasAudioSettings
    {
        /// <param name="programId">Programid</param>
        public EpisodeLatestDetailsRequest(int programId)
        {
            ProgramId = programId;
        }

        /// <summary>
        /// Programid
        /// </summary>
        public int ProgramId { get; }

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
