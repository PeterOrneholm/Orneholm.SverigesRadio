namespace Orneholm.SverigesRadio.Api.Models.Request.Common
{
    /// <summary>
    /// Detta request kan applicera ljudinställningar.
    /// </summary>
    public interface IHasAudioSettings
    {
        /// <summary>
        /// Ljudinställningar.
        /// </summary>
        AudioSettings AudioSettings { get; set; }
    }
}
