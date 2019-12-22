using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models;

namespace Orneholm.SverigesRadio.Api
{
    /// <summary>
    /// HTTP based client for the Sveriges Radio Open API.
    /// </summary>
    public class SverigesRadioApiClient : ISverigesRadioApiClient
    {
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
            return _httpClient.GetDetailsAsync<ProgramDetailsResponse>("programs", request);
        }

        public Task<ProgramListResponse> GetProgramsAsync(ProgramListRequest request)
        {
            return _httpClient.GetListAsync<ProgramListResponse>("programs", request, new Dictionary<string, string?>
            {
                { "channelid", request.ChannelId?.ToString("D") },
                { "programcategoryid ", request.ProgramCategoryId?.ToString("D") },
                { "isarchived", request.IsArchived?.ToString().ToLower() }
            });
        }
    }
}
