using System;
using System.Net.Http;
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
    /// HTTP based client for the Sveriges Radio Open API.
    /// </summary>
    public class SverigesRadioApiClient : ISverigesRadioApiClient
    {
        public static SverigesRadioApiClient CreateClient()
        {
            return CreateClient(SverigesRadioUrls.ProductionApiBaseUrl);
        }

        public static SverigesRadioApiClient CreateClient(Uri apiBaseUri)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = apiBaseUri
            };
            return new SverigesRadioApiClient(httpClient);
        }

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Creates an instance of <see cref="SverigesRadioApiClient"/> using the supplied <see cref="HttpClient"/> to talk HTTP.
        /// </summary>
        /// <param name="httpClient">The HttpClient to use.</param>
        public SverigesRadioApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Programs

        public Task<ProgramDetailsResponse> GetProgramAsync(ProgramDetailsRequest request)
        {
            return _httpClient.GetDetailsAsync<ProgramDetailsResponse>(Constants.Programs.BaseUrl, request);
        }

        public Task<ProgramListResponse> GetProgramsAsync(ProgramListRequest request, ListPagination? pagination = null)
        {
            return _httpClient.GetListAsync<ProgramListRequest, ProgramListResponse, ProgramListFilterFields, ProgramListSortFields>(
                Constants.Programs.ListEndpointConfiguration,
                request,
                pagination,
                request.Filter
            );
        }

        // ProgramCategories

        public Task<ProgramCategoryDetailsResponse> GetProgramCategoryAsync(ProgramCategoryDetailsRequest request)
        {
            return _httpClient.GetDetailsAsync<ProgramCategoryDetailsResponse>(Constants.ProgramCategories.BaseUrl, request);
        }

        public Task<ProgramCategoryListResponse> GetProgramCategoriesAsync(ProgramCategoryListRequest request, ListPagination? pagination = null)
        {
            return _httpClient.GetListAsync<ProgramCategoryListRequest, ProgramCategoryListResponse, ProgramCategoryListFilterFields, ProgramCategorySortFields>(
                Constants.ProgramCategories.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // Channels

        public Task<ChannelDetailsResponse> GetChannelAsync(ChannelDetailsRequest request)
        {
            return _httpClient.GetDetailsAsync<ChannelDetailsResponse>(Constants.Channels.BaseUrl, request);
        }

        public Task<ChannelListResponse> GetChannelsAsync(ChannelListRequest request, ListPagination? pagination = null)
        {
            return _httpClient.GetListAsync<ChannelListRequest, ChannelListResponse, ChannelListFilterFields, ChannelListSortFields>(
                Constants.Channels.ListEndpointConfiguration,
                request,
                pagination,
                request.Filter
            );
        }

        // Episodes

        public Task<EpisodeDetailsResponse> GetEpisodeAsync(EpisodeDetailsRequest request)
        {
            return _httpClient.GetDetailsAsync<EpisodeDetailsResponse>(Constants.Channels.BaseUrl, request);
        }

        public Task<EpisodeListResponse> GetEpisodesAsync(EpisodeListRequest request, ListPagination? pagination = null)
        {
            return _httpClient.GetListAsync<EpisodeListRequest, EpisodeListResponse, EpisodeListFilterFields, EpisodeListSortFields>(
                Constants.Episodes.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        public Task<EpisodeListResponse> SearchEpisodesAsync(EpisodeSearchRequest request, ListPagination? pagination = null)
        {
            return _httpClient.GetListAsync<EpisodeSearchRequest, EpisodeListResponse, EpisodeListFilterFields, EpisodeListSortFields>(
                Constants.Episodes.SearchEndpointConfiguration,
                request,
                pagination
            );
        }

        // Broadcasts

        public Task<BroadcastDetailsResponse> GetBroadcastAsync(BroadcastDetailsRequest request)
        {
            return _httpClient.GetDetailsAsync<BroadcastDetailsResponse>(Constants.Broadcasts.BaseUrl, request);
        }

        public Task<BroadcastListResponse> GetBroadcastsAsync(BroadcastListRequest request, ListPagination? pagination = null)
        {
            return _httpClient.GetListAsync<BroadcastListRequest, BroadcastListResponse, BroadcastListFilterFields, BroadcastListSortFields>(
                Constants.Broadcasts.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // Podfiles

        public Task<PodfileDetailsResponse> GetPodfileAsync(PodfileDetailsRequest request)
        {
            return _httpClient.GetDetailsAsync<PodfileDetailsResponse>(Constants.Podfiles.BaseUrl, request);
        }

        public Task<PodfileListResponse> GetPodfilesAsync(PodfileListRequest request, ListPagination? pagination = null)
        {
            return _httpClient.GetListAsync<PodfileListRequest, PodfileListResponse, PodfileListFilterFields, PodfileListSortFields>(
                Constants.Podfiles.ListEndpointConfiguration,
                request,
                pagination
            );
        }
    }
}
