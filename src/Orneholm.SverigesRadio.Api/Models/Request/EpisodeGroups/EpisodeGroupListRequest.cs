using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups
{
    public class EpisodeGroupListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Gruppid</param>
        public EpisodeGroupListRequest(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gruppid
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ljudinställningar.
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
