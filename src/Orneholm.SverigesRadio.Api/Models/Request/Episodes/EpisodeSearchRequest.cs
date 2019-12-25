using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeSearchRequest : ListRequestBase, IHasAudioSettings
    {
        public EpisodeSearchRequest(string query)
        {
            Query = query;
        }

        public string Query { get; set; }

        public int? ProgramId { get; set; }
        public int? KanalId { get; set; }
        public string ImageSize { get; set; } = string.Empty;

        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
