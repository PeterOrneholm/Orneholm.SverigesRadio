using System;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeListRequest : ListRequestBase, IHasAudioSettings
    {
        public EpisodeListRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
