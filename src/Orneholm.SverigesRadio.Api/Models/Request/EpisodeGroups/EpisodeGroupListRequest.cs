using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups
{
    public class EpisodeGroupListRequest : ListRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId">Gruppid</param>
        public EpisodeGroupListRequest(int groupId)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// Gruppid
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Ljudinställningar.
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
