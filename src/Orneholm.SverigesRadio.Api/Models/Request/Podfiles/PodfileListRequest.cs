using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Podfiles
{
    public class PodfileListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId">Programid</param>
        public PodfileListRequest(int programId)
        {
            ProgramId = programId;
        }

        /// <summary>
        /// Programid
        /// </summary>
        public int ProgramId { get; set; }

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
