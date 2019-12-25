using System.Text.Json.Serialization;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeSearchRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchQuery">Söfråga</param>
        public EpisodeSearchRequest(string searchQuery)
        {
            SearchQuery = searchQuery;
        }

        /// <summary>
        /// Sökfråga
        /// </summary>
        public string SearchQuery { get; set; }

        public int? ProgramId { get; set; }
        public int? ChannelId { get; set; }
        public string ImageSize { get; set; } = string.Empty;

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
