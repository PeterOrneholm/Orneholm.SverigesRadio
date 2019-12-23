namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public interface IAudioSettings
    {
        AudioQuality AudioQuality { get; set; }
        int? LiveAudioTemplateId { get; set; }
        int? OnDemandAudioTemplateId { get; set; }
    }
}
