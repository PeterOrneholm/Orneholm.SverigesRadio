using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Podfiles
{
    public class PodfileDetailsRequest : DetailsRequestBase, IHasAudioSettings
    {
        public PodfileDetailsRequest(int id)
        : base(id)
        {
        }

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
