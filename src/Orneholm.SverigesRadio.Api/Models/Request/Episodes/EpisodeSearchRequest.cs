using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeSearchRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">Söfråga</param>
        public EpisodeSearchRequest(string query)
        {
            Query = query;
        }

        /// <summary>
        /// Sökfråga
        /// </summary>
        public string Query { get; set; }

        public int? ProgramId { get; set; }
        public int? KanalId { get; set; }
        public string ImageSize { get; set; } = string.Empty;

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
