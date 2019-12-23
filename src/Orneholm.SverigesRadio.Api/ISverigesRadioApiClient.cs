using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
using Orneholm.SverigesRadio.Api.Models.Response.Episodes;
using Orneholm.SverigesRadio.Api.Models.Response.Programs;

namespace Orneholm.SverigesRadio.Api
{
    /// <summary>
    /// Sveriges Radio Open API Client.
    /// </summary>
    public interface ISverigesRadioApiClient
    {
        // Programs
        Task<ProgramDetailsResponse> GetProgramAsync(ProgramDetailsRequest request);
        Task<ProgramListResponse> GetProgramsAsync(ProgramListRequest request, ListPagination? pagination = null);

        // Channels
        Task<ChannelDetailsResponse> GetChannelAsync(ChannelDetailsRequest request);
        Task<ChannelListResponse> GetChannelsAsync(ChannelListRequest request, ListPagination? pagination = null);

        // Episodes
        Task<EpisodeDetailsResponse> GetEpisodeAsync(EpisodeDetailsRequest request);
        Task<EpisodeListResponse> GetEpisodesAsync(EpisodeListRequest request, ListPagination? pagination = null);
    }
}
