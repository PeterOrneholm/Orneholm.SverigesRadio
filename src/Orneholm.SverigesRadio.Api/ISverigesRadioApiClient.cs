using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
using Orneholm.SverigesRadio.Api.Models.Response.Episodes;
using Orneholm.SverigesRadio.Api.Models.Response.ProgramCategories;
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

        // ProgramCategories
        Task<ProgramCategoryDetailsResponse> GetProgramCategoryAsync(ProgramCategoryDetailsRequest request);
        Task<ProgramCategoryListResponse> GetProgramCategoriesAsync(ProgramCategoryListRequest request, ListPagination? pagination = null);

        // Channels
        Task<ChannelDetailsResponse> GetChannelAsync(ChannelDetailsRequest request);
        Task<ChannelListResponse> GetChannelsAsync(ChannelListRequest request, ListPagination? pagination = null);

        // Episodes
        Task<EpisodeDetailsResponse> GetEpisodeAsync(EpisodeDetailsRequest request);
        Task<EpisodeListResponse> GetEpisodesAsync(EpisodeListRequest request, ListPagination? pagination = null);

        // Broadcasts
        Task<BroadcastDetailsResponse> GetBroadcastAsync(BroadcastDetailsRequest request);
        Task<BroadcastListResponse> GetBroadcastsAsync(BroadcastListRequest request, ListPagination? pagination = null);

    }
}
