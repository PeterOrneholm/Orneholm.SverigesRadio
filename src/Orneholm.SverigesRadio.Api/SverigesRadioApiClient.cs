using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
using Orneholm.SverigesRadio.Api.Models.Response.Episodes;
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
    }
}
