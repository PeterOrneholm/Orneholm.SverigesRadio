using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
using Orneholm.SverigesRadio.Api.Models.Response.Episodes;
using Orneholm.SverigesRadio.Api.Models.Response.Podfiles;
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
        Task<ProgramListResponse> ListProgramsAsync(ProgramListRequest request, ListPagination? pagination = null);

        // ProgramCategories
        Task<ProgramCategoryDetailsResponse> GetProgramCategoryAsync(ProgramCategoryDetailsRequest request);
        Task<ProgramCategoryListResponse> ListProgramCategoriesAsync(ProgramCategoryListRequest request, ListPagination? pagination = null);

        // Channels
        Task<ChannelDetailsResponse> GetChannelAsync(ChannelDetailsRequest request);
        Task<ChannelListResponse> ListChannelsAsync(ChannelListRequest request, ListPagination? pagination = null);

        // Episodes
        Task<EpisodeDetailsResponse> GetEpisodeAsync(EpisodeDetailsRequest request);
        Task<EpisodeListResponse> GetEpisodesAsync(EpisodeDetailsMultipleRequest request, ListPagination? pagination = null);
        Task<EpisodeDetailsResponse> GetLatestEpisodeAsync(EpisodeLatestDetailsRequest request);
        Task<EpisodeListResponse> ListEpisodesAsync(EpisodeListRequest request, ListPagination? pagination = null);
        Task<EpisodeListResponse> SearchEpisodesAsync(EpisodeSearchRequest request, ListPagination? pagination = null);

        // Broadcasts
        Task<BroadcastDetailsResponse> GetBroadcastAsync(BroadcastDetailsRequest request);
        Task<BroadcastListResponse> ListBroadcastsAsync(BroadcastListRequest request, ListPagination? pagination = null);
        Task<BroadcastListResponse> ListExtraBroadcastsAsync(BroadcastListExtraRequest request, ListPagination? pagination = null);

        // Podfiles
        Task<PodfileDetailsResponse> GetPodfileAsync(PodfileDetailsRequest request);
        Task<PodfileListResponse> ListPodfilesAsync(PodfileListRequest request, ListPagination? pagination = null);
    }
}
