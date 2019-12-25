using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Channels
{
    public class ChannelListRequest : ListRequestBase, IHasAudioSettings
    {
        public string? ChannelType { get; set; } = null;

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
