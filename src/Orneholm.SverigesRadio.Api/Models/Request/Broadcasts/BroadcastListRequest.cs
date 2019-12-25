using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Broadcasts
{
    public class BroadcastListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId">Filtrera på program id.</param>
        public BroadcastListRequest(int programId)
        {
            ProgramId = programId;
        }

        /// <summary>
        /// Filtrera på program id.
        /// </summary>
        public int ProgramId { get; set; }

        /// <summary>
        /// Ljudinställningar.
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
