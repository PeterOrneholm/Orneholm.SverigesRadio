using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Broadcasts
{
    public class BroadcastListRequest : ListRequestBase, IHasAudioSettings
    {
        public BroadcastListRequest(int programId)
        {
            ProgramId = programId;
        }

        public int ProgramId { get; set; }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
