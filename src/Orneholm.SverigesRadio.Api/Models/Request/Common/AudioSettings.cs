namespace Orneholm.SverigesRadio.Api.Models.Request.Common
{
    /// <summary>
    /// Inställningar för ljud.
    /// </summary>
    public class AudioSettings
    {
        /// <summary>
        /// Ljudkvalitet
        /// </summary>
        public AudioQuality? AudioQuality { get; set; } = null;

        /// <summary>
        /// Format för liveljud. Se <see cref="SverigesRadioApiIds.LiveAudioTemplates"/> för en lista av värden.
        /// </summary>
        public int? LiveAudioTemplateId { get; set; }

        /// <summary>
        /// Format för efterhandslyssningsljud. Se <see cref="SverigesRadioApiIds.OnDemandAudioTemplates"/> för en lista av värden.
        /// </summary>
        public int? OnDemandAudioTemplateId { get; set; }
    }
}
