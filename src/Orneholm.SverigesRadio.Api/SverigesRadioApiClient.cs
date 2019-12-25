using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Common;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
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
            return GetDetailsAsync<ProgramDetailsResponse>(_httpClient, Constants.Programs.BaseUrl, request);
        }

        public Task<ProgramListResponse> ListProgramsAsync(ProgramListRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<ProgramListRequest, ProgramListResponse, ProgramListFilterFields>(
                _httpClient,
                Constants.Programs.ListEndpointConfiguration,
                request,
                pagination,
                request.Filter
            );
        }

        // ProgramCategories

        public Task<ProgramCategoryDetailsResponse> GetProgramCategoryAsync(ProgramCategoryDetailsRequest request)
        {
            return GetDetailsAsync<ProgramCategoryDetailsResponse>(_httpClient, Constants.ProgramCategories.BaseUrl, request);
        }

        public Task<ProgramCategoryListResponse> ListProgramCategoriesAsync(ProgramCategoryListRequest request, ListPagination? pagination = null)
        {
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
            return GetDetailsAsync<ChannelDetailsResponse>(_httpClient, Constants.Channels.BaseUrl, request);
        }

        public Task<ChannelListResponse> ListChannelsAsync(ChannelListRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<ChannelListRequest, ChannelListResponse, ChannelListFilterFields>(
                _httpClient,
                Constants.Channels.ListEndpointConfiguration,
                request,
                pagination,
                request.Filter
            );
        }

        // Episodes

        public Task<EpisodeDetailsResponse> GetEpisodeAsync(EpisodeDetailsRequest request)
        {
            return GetDetailsAsync<EpisodeDetailsResponse>(_httpClient, Constants.Channels.BaseUrl, request);
        }

        public async Task<EpisodeListResponse> GetEpisodesAsync(EpisodeDetailsMultipleRequest request, ListPagination? pagination = null)
        {
            var result = await GetListAsync<EpisodeDetailsMultipleRequest, EpisodeListResponse>(
                _httpClient,
                Constants.Episodes.DetailsMultipleUrlEndpointConfiguration,
                request,
                pagination
            ).ConfigureAwait(false);

            result.Pagination.TotalHits = request.Ids.Count;

            return result;
        }

        public Task<EpisodeDetailsResponse> GetLatestEpisodeAsync(EpisodeLatestDetailsRequest request)
        {
            var queryStringParams = new Dictionary<string, string?>();
            SverigesRadioUrlHelpers.AddAudioSettingsQueryStringParams(queryStringParams, request.AudioSettings);

            queryStringParams[Constants.Episodes.QueryString.ProgramId] = request.ProgramId.ToString("D");

            var fullUrl = $"{Constants.Episodes.GetLatestUrl}";
            return _httpClient.GetAsync<EpisodeDetailsResponse>(fullUrl, queryStringParams);
        }

        public Task<EpisodeListResponse> ListEpisodesAsync(EpisodeListRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<EpisodeListRequest, EpisodeListResponse>(
                _httpClient,
                Constants.Episodes.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        public Task<EpisodeListResponse> SearchEpisodesAsync(EpisodeSearchRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<EpisodeSearchRequest, EpisodeListResponse>(
                _httpClient,
                Constants.Episodes.SearchEndpointConfiguration,
                request,
                pagination
            );
        }

        // Broadcasts

        public Task<BroadcastListResponse> ListBroadcastsAsync(BroadcastListRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<BroadcastListRequest, BroadcastListResponse>(
                _httpClient,
                Constants.Broadcasts.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        public Task<ExtraBroadcastListResponse> ListExtraBroadcastsAsync(ExtraBroadcastListRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<ExtraBroadcastListRequest, ExtraBroadcastListResponse, NoneListFilterFields>(
                _httpClient,
                Constants.ExtraBroadcasts.ListEndpointConfiguration,
                request,
                pagination
            );
        }

        // Podfiles

        public Task<PodfileDetailsResponse> GetPodfileAsync(PodfileDetailsRequest request)
        {
            return GetDetailsAsync<PodfileDetailsResponse>(_httpClient, Constants.Podfiles.BaseUrl, request);
        }

        public Task<PodfileListResponse> ListPodfilesAsync(PodfileListRequest request, ListPagination? pagination = null)
        {
            return GetListAsync<PodfileListRequest, PodfileListResponse>(
                _httpClient,
                Constants.Podfiles.ListEndpointConfiguration,
                request,
                pagination
            );
        }


        // Internal

        private static Task<TResult> GetDetailsAsync<TResult>(HttpClient httpClient, string url, DetailsRequestBase request, Dictionary<string, string?>? queryStringParams = null)
        {
            queryStringParams ??= new Dictionary<string, string?>();

            if (request is IHasAudioSettings audioSettings)
            {
                SverigesRadioUrlHelpers.AddAudioSettingsQueryStringParams(queryStringParams, audioSettings.AudioSettings);
            }

            var fullUrl = $"{url}/{request.Id:D}";
            return httpClient.GetAsync<TResult>(fullUrl, queryStringParams);
        }

        private static Task<TResult> GetListAsync<TRequest, TResult>(HttpClient httpClient, SverigesRadioApiListEndpointConfiguration<TRequest, NoneListFilterFields> listEndpointConfiguration, TRequest request, ListPagination? pagination = null) where TRequest : ListRequestBase
        {
            return GetListAsync<TRequest, TResult, NoneListFilterFields>(httpClient, listEndpointConfiguration, request, pagination);
        }

        private static Task<TResult> GetListAsync<TRequest, TResult, TFilterField>(HttpClient httpClient, SverigesRadioApiListEndpointConfiguration<TRequest, TFilterField> listEndpointConfiguration, TRequest request, ListPagination? pagination = null, ListFilter<TFilterField>? filter = null) where TRequest : ListRequestBase where TFilterField : Enum
        {
            var queryStringParams = new Dictionary<string, string?>();

            SverigesRadioUrlHelpers.AddPaginationQueryStringParams(queryStringParams, pagination);

            SverigesRadioUrlHelpers.AddFilterQueryStringParams(queryStringParams, listEndpointConfiguration.FilterFieldResolver, filter);

            if (request is IHasAudioSettings audioSettings)
            {
                SverigesRadioUrlHelpers.AddAudioSettingsQueryStringParams(queryStringParams, audioSettings.AudioSettings);
            }

            if (listEndpointConfiguration.QueryStringParamsResolver != null)
            {
                SverigesRadioUrlHelpers.AddQueryStringParams(queryStringParams, request, listEndpointConfiguration.QueryStringParamsResolver);
            }

            return httpClient.GetAsync<TResult>(listEndpointConfiguration.Url, queryStringParams);
        }
    }

    internal static class SverigesRadioUrlHelpers
    {
        private static readonly ListPagination DefaultPagination = ListPagination.FirstPage();

        public static void AddQueryStringParams<TRequest>(Dictionary<string, string?> queryStringParams, TRequest request, Action<TRequest, Dictionary<string, string?>> queryStringParamsResolver) where TRequest : ListRequestBase
        {
            queryStringParamsResolver?.Invoke(request, queryStringParams);
        }

        public static void AddPaginationQueryStringParams(Dictionary<string, string?> queryStringParams, ListPagination? pagination)
        {
            pagination ??= DefaultPagination;

            if (pagination.PaginationEnabled)
            {
                queryStringParams[Constants.Common.QueryString.PaginationEnabled] = Constants.Common.QueryString.True;

                if (pagination.PageNumber.HasValue)
                {
                    queryStringParams[Constants.Common.QueryString.PaginationPage] = pagination.PageNumber.Value.ToString("D");
                }

                if (pagination.PageSize.HasValue)
                {
                    queryStringParams[Constants.Common.QueryString.PaginationPageSize] = pagination.PageSize.Value.ToString("D");
                }
            }
            else
            {
                queryStringParams[Constants.Common.QueryString.PaginationEnabled] = Constants.Common.QueryString.False;
            }
        }

        public static void AddFilterQueryStringParams<TFilterField>(Dictionary<string, string?> queryStringParams, Func<TFilterField, string>? filterFieldResolver, ListFilter<TFilterField>? requestFilter) where TFilterField : Enum
        {
            if (requestFilter == null || filterFieldResolver == null)
            {
                return;
            }

            queryStringParams[Constants.Common.QueryString.FilterField] = filterFieldResolver.Invoke(requestFilter.Field);
            queryStringParams[Constants.Common.QueryString.FilterValue] = requestFilter.Value;
        }

        public static void AddSortQueryStringParams<TSortField>(Dictionary<string, string?> queryStringParams, Func<TSortField, string>? sortFieldResolver, List<ListSort<TSortField>>? requestSort) where TSortField : Enum
        {
            if (requestSort == null || !requestSort.Any() || sortFieldResolver == null)
            {
                return;
            }

            var sortString = new StringBuilder();

            foreach (var sort in requestSort)
            {
                sortString.Append(sortFieldResolver.Invoke(sort.Field));

                if (sort.SortDesc)
                {
                    sortString.Append(Constants.Common.QueryString.SortDescSuffix);
                }

                sortString.Append(Constants.Common.QueryString.SortFieldSeparator);
            }

            queryStringParams[Constants.Common.QueryString.Sort] = sortString.ToString().TrimEnd(Constants.Common.QueryString.SortFieldSeparator);
        }

        public static void AddAudioSettingsQueryStringParams(Dictionary<string, string?> queryStringParams, AudioSettings audioSettings)
        {
            queryStringParams[Constants.Common.QueryString.AudioQuality] = GetAudioQuality(audioSettings.AudioQuality);

            if (audioSettings.LiveAudioTemplateId.HasValue)
            {
                queryStringParams[Constants.Common.QueryString.LiveAudioTemplateId] = audioSettings.LiveAudioTemplateId.Value.ToString("D");
            }
            if (audioSettings.OnDemandAudioTemplateId.HasValue)
            {
                queryStringParams[Constants.Common.QueryString.OnDemandAudioTemplateId] = audioSettings.OnDemandAudioTemplateId.Value.ToString("D");
            }
        }

        public static string GetAudioQuality(AudioQuality audioQuality)
        {
            return audioQuality switch
            {
                AudioQuality.Normal => Constants.Common.QueryString.AudioQualityNormal,
                AudioQuality.Low => Constants.Common.QueryString.AudioQualityLow,
                AudioQuality.High => Constants.Common.QueryString.AudioQualityHigh,

                _ => string.Empty
            };
        }
    }
}
