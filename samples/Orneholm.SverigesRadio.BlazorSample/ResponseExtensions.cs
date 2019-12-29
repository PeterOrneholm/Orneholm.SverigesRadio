using Orneholm.SverigesRadio.Api.Models.Response.Episodes;

namespace Orneholm.SverigesRadio.BlazorSample
{
    public static class ResponseExtensions
    {
        public static EpisodePodfile GetEpisodePodfile(this Episode episode)
        {
            return episode.ListenPodfile ?? episode.DownloadPodfile;
        }
    }
}
