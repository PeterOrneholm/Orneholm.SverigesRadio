using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Broadcasts
{
    public class BroadcastDetailsRequest : DetailsRequestBase, IHasAudioSettings
    {
        public BroadcastDetailsRequest(int id)
        : base(id)
        {
        }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
