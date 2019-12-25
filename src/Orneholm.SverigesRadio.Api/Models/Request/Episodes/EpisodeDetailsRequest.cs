using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api.Models.Request.Episodes
{
    public class EpisodeDetailsRequest : DetailsRequestBase, IHasAudioSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Avsnitts id</param>
        public EpisodeDetailsRequest(int id)
        : base(id)
        {
        }

        /// <summary>
        /// Ljudinställningar
        /// </summary>
        public AudioSettings AudioSettings { get; set; } = new AudioSettings();
    }
}
