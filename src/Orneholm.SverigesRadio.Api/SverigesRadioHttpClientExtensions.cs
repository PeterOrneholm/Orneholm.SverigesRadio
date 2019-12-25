using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Common;
using Orneholm.SverigesRadio.Api.Serialization;

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
