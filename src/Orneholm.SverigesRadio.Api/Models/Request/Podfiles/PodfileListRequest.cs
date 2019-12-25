using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Podfiles
{
    public class PodfileListRequest : ListRequestBase, IHasAudioSettings
    {
        public PodfileListRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; set; }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
