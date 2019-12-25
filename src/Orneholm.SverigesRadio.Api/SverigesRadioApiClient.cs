using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.AudioUrlTemplates;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Common;
using Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.ExtraBroadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response.AudioUrlTemplates;
using Orneholm.SverigesRadio.Api.Models.Response.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
using Orneholm.SverigesRadio.Api.Models.Response.EpisodeGroups;
using Orneholm.SverigesRadio.Api.Models.Response.Episodes;
using Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts;
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

        public static SverigesRadioApiClient CreateClient(AudioSettings defaultAudioSettings)
        {
            return CreateClient(defaultAudioSettings, SverigesRadioUrls.ProductionApiBaseUrl);
        }

        public static SverigesRadioApiClient CreateClient(AudioSettings defaultAudioSettings, Uri apiBaseUri)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = apiBaseUri
            };
            return new SverigesRadioApiClient(httpClient, defaultAudioSettings);
        }

        private readonly HttpClient _httpClient;
        private readonly AudioSettings _defaultAudioSettings;

        public SverigesRadioApiClient(HttpClient httpClient)
        : this(httpClient, new AudioSettings())
        {
        }

        public SverigesRadioApiClient(HttpClient httpClient, AudioSettings defaultAudioSettings)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _defaultAudioSettings = defaultAudioSettings ?? throw new ArgumentNullException(nameof(defaultAudioSettings));
        }

        // Programs

        public Task<ProgramDetailsResponse> GetProgramAsync(ProgramDetailsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetDetailsAsync<ProgramDetailsResponse>(_httpClient, Constants.Programs.BaseUrl, request);
        }

        public Task<ProgramListResponse> ListProgramsAsync(ProgramListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<ProgramListRequest, ProgramListResponse>(
                _httpClient,
                Constants.Programs.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        public Task<ProgramNewsListResponse> ListProgramNewsAsync(ProgramNewsListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _httpClient.GetAsync<ProgramNewsListResponse>(Constants.News.ProgramNewsListUrl);
        }

        // ProgramCategories

        public Task<ProgramCategoryDetailsResponse> GetProgramCategoryAsync(ProgramCategoryDetailsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetDetailsAsync<ProgramCategoryDetailsResponse>(_httpClient, Constants.ProgramCategories.BaseUrl, request);
        }

        public Task<ProgramCategoryListResponse> ListProgramCategoriesAsync(ProgramCategoryListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<ProgramCategoryListRequest, ProgramCategoryListResponse>(
                _httpClient,
                Constants.ProgramCategories.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // Channels

        public Task<ChannelDetailsResponse> GetChannelAsync(ChannelDetailsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetDetailsAsync<ChannelDetailsResponse>(_httpClient, Constants.Channels.BaseUrl, request);
        }

        public Task<ChannelListResponse> ListChannelsAsync(ChannelListRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<ChannelListRequest, ChannelListResponse>(
                _httpClient,
                Constants.Channels.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // Episodes

        public Task<EpisodeDetailsResponse> GetEpisodeAsync(EpisodeDetailsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetDetailsAsync<EpisodeDetailsResponse>(_httpClient, Constants.Channels.BaseUrl, request);
        }

        public async Task<EpisodeListResponse> GetEpisodesAsync(EpisodeDetailsMultipleRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var result = await GetListAsync<EpisodeDetailsMultipleRequest, EpisodeListResponse>(
                _httpClient,
                Constants.Episodes.DetailsMultipleEndpointConfiguration,
                request,
                pagination
            ).ConfigureAwait(false);

            result.Pagination.TotalHits = request.Ids.Count;

            return result;
        }

        public Task<EpisodeDetailsResponse> GetLatestEpisodeAsync(EpisodeLatestDetailsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var queryStringParams = new Dictionary<string, string?>();
            UrlHelpers.AddAudioSettingsQueryStringParams(queryStringParams, request.AudioSettings, _defaultAudioSettings);

            queryStringParams[Constants.Episodes.QueryString.ProgramId] = request.ProgramId.ToString("D");

            return _httpClient.GetAsync<EpisodeDetailsResponse>(Constants.Episodes.GetLatestUrl, queryStringParams);
        }

        public Task<EpisodeListResponse> ListEpisodesAsync(EpisodeListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<EpisodeListRequest, EpisodeListResponse>(
                _httpClient,
                Constants.Episodes.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        public Task<EpisodeListResponse> SearchEpisodesAsync(EpisodeSearchRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<EpisodeSearchRequest, EpisodeListResponse>(
                _httpClient,
                Constants.Episodes.SearchEndpointConfiguration,
                request,
                pagination
            );
        }

        public Task<EpisodeNewsListResponse> ListEpisodeNewsAsync(EpisodeNewsListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _httpClient.GetAsync<EpisodeNewsListResponse>(Constants.News.EpisodeNewsListUrl);
        }

        // EpisodeGroups

        public Task<EpisodeGroupListResponse> ListEpisodeGroupsAsync(EpisodeGroupListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<EpisodeGroupListRequest, EpisodeGroupListResponse>(
                _httpClient,
                Constants.EpisodeGroups.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // Broadcasts

        public Task<BroadcastListResponse> ListBroadcastsAsync(BroadcastListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<BroadcastListRequest, BroadcastListResponse>(
                _httpClient,
                Constants.Broadcasts.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        public Task<ExtraBroadcastListResponse> ListExtraBroadcastsAsync(ExtraBroadcastListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<ExtraBroadcastListRequest, ExtraBroadcastListResponse>(
                _httpClient,
                Constants.ExtraBroadcasts.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // Podfiles

        public Task<PodfileDetailsResponse> GetPodfileAsync(PodfileDetailsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetDetailsAsync<PodfileDetailsResponse>(_httpClient, Constants.Podfiles.BaseUrl, request);
        }

        public Task<PodfileListResponse> ListPodfilesAsync(PodfileListRequest request, ListPagination? pagination = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GetListAsync<PodfileListRequest, PodfileListResponse>(
                _httpClient,
                Constants.Podfiles.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // AudioUrlTemplates

        public Task<OnDemandAudioTypesListResponse> ListOnDemandAudioTypesAsync(OnDemandAudioTypesListRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _httpClient.GetAsync<OnDemandAudioTypesListResponse>(Constants.AudioUrlTemplates.OnDemandTypesListUrl);
        }

        public Task<LivedAudioTypesListResponse> ListLiveAudioTypesAsync(LiveAudioTypesListRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _httpClient.GetAsync<LivedAudioTypesListResponse>(Constants.AudioUrlTemplates.LiveAudioTypesListUrl);
        }

        // Internal

        private Task<TResult> GetDetailsAsync<TResult>(HttpClient httpClient, string url, DetailsRequestBase request, Dictionary<string, string?>? queryStringParams = null)
        {
            return GetDetailsAsync<TResult>(httpClient, url, request, queryStringParams, _defaultAudioSettings);
        }

        private static Task<TResult> GetDetailsAsync<TResult>(HttpClient httpClient, string url, DetailsRequestBase request, Dictionary<string, string?>? queryStringParams, AudioSettings defaultAudioSettings)
        {
            queryStringParams ??= new Dictionary<string, string?>();

            if (request is IHasAudioSettings audioSettings)
            {
                UrlHelpers.AddAudioSettingsQueryStringParams(queryStringParams, audioSettings.AudioSettings, defaultAudioSettings);
            }

            var fullUrl = $"{url}/{request.Id:D}";
            return httpClient.GetAsync<TResult>(fullUrl, queryStringParams);
        }

        private Task<TResult> GetListAsync<TRequest, TResult>(HttpClient httpClient, ListEndpointConfiguration<TRequest> listEndpointConfiguration, TRequest request, ListPagination? pagination = null) where TRequest : ListRequestBase
        {
            return GetListAsync<TRequest, TResult>(httpClient, listEndpointConfiguration, request, pagination, _defaultAudioSettings);
        }

        private static Task<TResult> GetListAsync<TRequest, TResult>(HttpClient httpClient, ListEndpointConfiguration<TRequest> listEndpointConfiguration, TRequest request, ListPagination? pagination, AudioSettings defaultAudioSettings) where TRequest : ListRequestBase
        {
            var queryStringParams = new Dictionary<string, string?>();

            UrlHelpers.AddPaginationQueryStringParams(queryStringParams, pagination);

            if (request is IHasAudioSettings audioSettings)
            {
                UrlHelpers.AddAudioSettingsQueryStringParams(queryStringParams, audioSettings.AudioSettings, defaultAudioSettings);
            }

            if (listEndpointConfiguration.QueryStringParamsResolver != null)
            {
                UrlHelpers.AddQueryStringParams(queryStringParams, request, listEndpointConfiguration.QueryStringParamsResolver);
            }

            return httpClient.GetAsync<TResult>(listEndpointConfiguration.Url, queryStringParams);
        }
    }
}
