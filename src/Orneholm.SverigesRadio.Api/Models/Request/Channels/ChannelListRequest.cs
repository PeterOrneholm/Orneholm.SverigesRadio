using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Channels
{
    public class ChannelListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// Filter of the result.
        /// </summary>
        public ListFilter<ChannelListFilterFields>? Filter { get; set; } = null;

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
