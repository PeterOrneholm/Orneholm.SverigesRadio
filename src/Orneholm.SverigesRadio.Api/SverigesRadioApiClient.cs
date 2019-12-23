using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
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

        public Task<ProgramDetailsResponse> GetProgramAsync(ProgramDetailsRequest request)
        {
            return _httpClient.GetDetailsAsync<ProgramDetailsResponse>(Constants.Programs.BaseUrl, request);
        }

        public Task<ProgramListResponse> GetProgramsAsync(ProgramListRequest request)
        {
            return _httpClient.GetListAsync<ProgramListResponse>(Constants.Programs.BaseUrl, request, new Dictionary<string, string?>
            {
                { Constants.Programs.QueryString.ChannelId, request.ChannelId?.ToString("D") },
                { Constants.Programs.QueryString.ProgramCategoryId, request.ProgramCategoryId?.ToString("D") },
                { Constants.Programs.QueryString.IsArchived, request.IsArchived?.ToString().ToLower() }
            });
        }
    }
}
