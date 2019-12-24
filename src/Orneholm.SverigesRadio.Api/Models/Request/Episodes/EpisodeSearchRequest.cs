using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeSearchRequest : ListRequestBase, IAudioSettings
    {
        public EpisodeSearchRequest(string query)
        {
            Query = query;
        }

        public string Query { get; set; }

        public int? ProgramId { get; set; }
        public int? KanalId { get; set; }
        public string ImageSize { get; set; } = string.Empty;

        public AudioQuality AudioQuality { get; set; } = AudioQuality.Normal;
        public int? LiveAudioTemplateId { get; set; } = null;
        public int? OnDemandAudioTemplateId { get; set; } = null;
    }
}
