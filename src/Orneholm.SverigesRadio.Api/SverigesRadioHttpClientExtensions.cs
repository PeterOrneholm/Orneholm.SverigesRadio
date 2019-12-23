using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models;
using Orneholm.SverigesRadio.Api.Models.Request;

namespace Orneholm.SverigesRadio.Api
{
    internal static class SverigesRadioHttpClientExtensions
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public static Task<TResult> GetDetailsAsync<TResult>(this HttpClient httpClient, string url, DetailsRequestBase request, Dictionary<string, string?>? queryStringParams = null)
        {
            var fullUrl = $"{url}/{request.Id:D}";
            return httpClient.GetAsync<TResult>(fullUrl, queryStringParams);
        }

        public static Task<TResult> GetListAsync<TResult>(this HttpClient httpClient, string url, ListRequestBase request, Dictionary<string, string?>? queryStringParams = null)
        {
            queryStringParams ??= new Dictionary<string, string?>();

            AddPaginationQueryStringParams(request.Pagination, queryStringParams);
            AddSortQueryStringParams(request.Sort, queryStringParams);
            AddFilterQueryStringParams(request.Filter, queryStringParams);

            return httpClient.GetAsync<TResult>(url, queryStringParams);
        }

        private static void AddPaginationQueryStringParams(ListPagination pagination, Dictionary<string, string?> queryStringParams)
        {
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

        private static void AddSortQueryStringParams(List<ListSort> requestSort, Dictionary<string, string?> queryStringParams)
        {
            if (!requestSort.Any())
            {
                return;
            }

            var sortString = new StringBuilder();

            foreach (var sort in requestSort)
            {
                sortString.Append(sort.Field);

                if (sort.SortDesc)
                {
                    sortString.Append(Constants.Common.QueryString.SortDescSuffix);
                }

                sortString.Append(Constants.Common.QueryString.SortFieldSeparator);
            }

            queryStringParams[Constants.Common.QueryString.Sort] = sortString.ToString().TrimEnd(Constants.Common.QueryString.SortFieldSeparator);
        }

        private static void AddFilterQueryStringParams(ListFilter? requestFilter, Dictionary<string, string?> queryStringParams)
        {
            if (requestFilter != null)
            {
                queryStringParams[Constants.Common.QueryString.FilterField] = requestFilter.Field;
                queryStringParams[Constants.Common.QueryString.FilterValue] = requestFilter.Value;
            }
        }

        private static async Task<TResult> GetAsync<TResult>(this HttpClient httpClient, string url, Dictionary<string, string?>? queryStringParams = null)
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
