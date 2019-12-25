using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Channels
{
    public class ChannelListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// Filtrera på kanaltyp. Se <see cref="SverigesRadioApiIds.ChannelTypes"/> för en lista av värden.
        /// </summary>
        public string? ChannelType { get; set; } = null;

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
