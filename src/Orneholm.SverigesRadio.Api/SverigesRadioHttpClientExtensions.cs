using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Common;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;

namespace Orneholm.SverigesRadio.Api
{
    internal static class SverigesRadioHttpClientExtensions
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsDateTimeJsonConverter()
            }
        };

        private static readonly ListPagination DefaultPagination = ListPagination.FirstPage();

        public static Task<TResult> GetDetailsAsync<TResult>(this HttpClient httpClient, string url, DetailsRequestBase request, Dictionary<string, string?>? queryStringParams = null)
        {
            queryStringParams ??= new Dictionary<string, string?>();

            if (request is IHasAudioSettings audioSettings)
            {
                AddAudioSettingsQueryStringParams(queryStringParams, audioSettings.AudioSettings);
            }

            var fullUrl = $"{url}/{request.Id:D}";
            return httpClient.GetAsync<TResult>(fullUrl, queryStringParams);
        }

        public static Task<TResult> GetListAsync<TRequest, TResult>(this HttpClient httpClient, SverigesRadioApiListEndpointConfiguration<TRequest, NoneListFilterFields, NoneListSortFields> listEndpointConfiguration, TRequest request, ListPagination? pagination = null) where TRequest : ListRequestBase
        {
            return httpClient.GetListAsync<TRequest, TResult, NoneListFilterFields, NoneListSortFields>(listEndpointConfiguration, request, pagination);
        }

        public static Task<TResult> GetListAsync<TRequest, TResult, TFilterField>(this HttpClient httpClient, SverigesRadioApiListEndpointConfiguration<TRequest, TFilterField, NoneListSortFields> listEndpointConfiguration, TRequest request, ListPagination? pagination = null, ListFilter<TFilterField>? filter = null) where TRequest : ListRequestBase where TFilterField : Enum
        {
            return httpClient.GetListAsync<TRequest, TResult, TFilterField, NoneListSortFields>(listEndpointConfiguration, request, pagination, filter);
        }

        public static Task<TResult> GetListAsync<TRequest, TResult, TFilterField, TSortField>(this HttpClient httpClient, SverigesRadioApiListEndpointConfiguration<TRequest, TFilterField, TSortField> listEndpointConfiguration, TRequest request, ListPagination? pagination = null, ListFilter<TFilterField>? filter = null, List<ListSort<TSortField>>? sort = null) where TRequest : ListRequestBase where TFilterField : Enum where TSortField : Enum
        {
            var queryStringParams = new Dictionary<string, string?>();

            AddPaginationQueryStringParams(queryStringParams, pagination);

            AddFilterQueryStringParams(queryStringParams, listEndpointConfiguration.FilterFieldResolver, filter);
            AddSortQueryStringParams(queryStringParams, listEndpointConfiguration.SortFieldResolver, sort);

            if (request is IHasAudioSettings audioSettings)
            {
                AddAudioSettingsQueryStringParams(queryStringParams, audioSettings.AudioSettings);
            }

            if (listEndpointConfiguration.QueryStringParamsResolver != null)
            {
                AddQueryStringParams(queryStringParams, request, listEndpointConfiguration.QueryStringParamsResolver);
            }

            return httpClient.GetAsync<TResult>(listEndpointConfiguration.Url, queryStringParams);
        }

        private static void AddQueryStringParams<TRequest>(Dictionary<string, string?> queryStringParams, TRequest request, Action<TRequest, Dictionary<string, string?>> queryStringParamsResolver) where TRequest : ListRequestBase
        {
            queryStringParamsResolver?.Invoke(request, queryStringParams);
        }

        private static void AddPaginationQueryStringParams(Dictionary<string, string?> queryStringParams, ListPagination? pagination)
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

        private static void AddFilterQueryStringParams<TFilterField>(Dictionary<string, string?> queryStringParams, Func<TFilterField, string>? filterFieldResolver, ListFilter<TFilterField>? requestFilter) where TFilterField : Enum
        {
            if (requestFilter == null || filterFieldResolver == null)
            {
                return;
            }

            queryStringParams[Constants.Common.QueryString.FilterField] = filterFieldResolver.Invoke(requestFilter.Field);
            queryStringParams[Constants.Common.QueryString.FilterValue] = requestFilter.Value;
        }

        private static void AddSortQueryStringParams<TSortField>(Dictionary<string, string?> queryStringParams, Func<TSortField, string>? sortFieldResolver, List<ListSort<TSortField>>? requestSort) where TSortField : Enum
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

        private static string GetAudioQuality(AudioQuality audioQuality)
        {
            return audioQuality switch
            {
                AudioQuality.Normal => Constants.Common.QueryString.AudioQualityNormal,
                AudioQuality.Low => Constants.Common.QueryString.AudioQualityLow,
                AudioQuality.High => Constants.Common.QueryString.AudioQualityHigh,

                _ => string.Empty
            };
        }

        internal static async Task<TResult> GetAsync<TResult>(this HttpClient httpClient, string url, Dictionary<string, string?>? queryStringParams = null)
        {
            queryStringParams = AddDefaultQueryStringParams(queryStringParams);

            var fullUrl = GetUrl(url, queryStringParams);
            var httpResponseMessage = await httpClient.GetAsync(fullUrl).ConfigureAwait(false);

            httpResponseMessage.EnsureSuccessStatusCode();

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var parsedContent = await JsonSerializer.DeserializeAsync<TResult>(contentStream, JsonSerializerOptions).ConfigureAwait(false);

            return parsedContent;
        }

        private static Dictionary<string, string?> AddDefaultQueryStringParams(Dictionary<string, string?>? queryStringParams)
        {
            queryStringParams ??= new Dictionary<string, string?>();

            queryStringParams[Constants.Common.QueryString.Format] = Constants.Common.QueryString.FormatJson;
            queryStringParams[Constants.Common.QueryString.Indent] = Constants.Common.QueryString.False;

            return queryStringParams;
        }

        private static string GetUrl(string baseUrl, Dictionary<string, string?>? queryStringParams)
        {
            if (queryStringParams == null || !queryStringParams.Any())
            {
                return baseUrl;
            }

            var queryStringParamsWithValues = queryStringParams.Where(x => !string.IsNullOrEmpty(x.Key));
            var queryString = string.Join("&", queryStringParamsWithValues.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value ?? string.Empty)}"));
            return $"{baseUrl}?{queryString}";
        }
    }
}
