using System;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <param name="programId">Programid</param>
        public EpisodeListRequest(int programId)
        {
            ProgramId = programId;
        }

        /// <summary>
        /// Programid
        /// </summary>
        public int ProgramId { get; set; }

        /// <summary>
        /// Filtrera från kl 00:00 detta datum.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Filtrera till kl 00:00 detta datum.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
