using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.ExtraBroadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response;
using Orneholm.SverigesRadio.Api.Models.Response.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
using Orneholm.SverigesRadio.Api.Models.Response.EpisodeGroups;
using Orneholm.SverigesRadio.Api.Models.Response.Episodes;
using Orneholm.SverigesRadio.Api.Models.Response.ExtraBroadcasts;
using Orneholm.SverigesRadio.Api.Models.Response.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Response.Programs;

namespace Orneholm.SverigesRadio.Api
{
    /// <summary>
    /// Extensions to enable easier access to common api scenarios.
    /// </summary>
    public static class SverigesRadioApiClientExtensions
    {
#if NETSTANDARD2_1
        public static IAsyncEnumerable<Program> ListAllProgramsAsync(this ISverigesRadioApiClient apiClient, ProgramListRequest request)
        {
            return apiClient.ListAllAsync<Program, ProgramListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListProgramsAsync(request, pagination);
                return (result.Programs, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Models.Response.ProgramCategories.ProgramCategory> ListAllProgramCategoriesAsync(this ISverigesRadioApiClient apiClient, ProgramCategoryListRequest request)
        {
            return apiClient.ListAllAsync<Models.Response.ProgramCategories.ProgramCategory, ProgramCategoryListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListProgramCategoriesAsync(request, pagination);
                return (result.ProgramCategories, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Episode> ListAllEpisodesAsync(this ISverigesRadioApiClient apiClient, EpisodeListRequest request)
        {
            return apiClient.ListAllAsync<Episode, EpisodeListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListEpisodesAsync(request, pagination);
                return (result.Episodes, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Episode> SearchAllEpisodesAsync(this ISverigesRadioApiClient apiClient, EpisodeSearchRequest request)
        {
            return apiClient.ListAllAsync<Episode, EpisodeSearchRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.SearchEpisodesAsync(request, pagination);
                return (result.Episodes, result.Pagination);
            });
        }

        public static IAsyncEnumerable<EpisodeGroupEpisode> ListAllEpisodeGroupsAsync(this ISverigesRadioApiClient apiClient, EpisodeGroupListRequest request)
        {
            return apiClient.ListAllAsync<EpisodeGroupEpisode, EpisodeGroupListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListEpisodeGroupsAsync(request, pagination);
                return (result.EpisodeGroup.Episodes, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Channel> ListAllChannelsAsync(this ISverigesRadioApiClient apiClient, ChannelListRequest request)
        {
            return apiClient.ListAllAsync<Channel, ChannelListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListChannelsAsync(request, pagination);
                return (result.Channels, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Broadcast> ListAllBroadcastsAsync(this ISverigesRadioApiClient apiClient, BroadcastListRequest request)
        {
            return apiClient.ListAllAsync<Broadcast, BroadcastListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListBroadcastsAsync(request, pagination);
                return (result.Broadcasts, result.Pagination);
            });
        }

        public static IAsyncEnumerable<ExtraBroadcast> ListAllExtraBroadcastsAsync(this ISverigesRadioApiClient apiClient, ExtraBroadcastListRequest request)
        {
            return apiClient.ListAllAsync<ExtraBroadcast, ExtraBroadcastListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListExtraBroadcastsAsync(request, pagination);
                return (result.Broadcasts, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Podfile> ListAllPodfilesAsync(this ISverigesRadioApiClient apiClient, PodfileListRequest request)
        {
            return apiClient.ListAllAsync<Podfile, PodfileListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListPodfilesAsync(request, pagination);
                return (result.Podfiles, result.Pagination);
            });
        }




        private static async IAsyncEnumerable<TItem> ListAllAsync<TItem, TRequest>(this ISverigesRadioApiClient apiClient, TRequest request, Func<TRequest, ListPagination, Task<(IEnumerable<TItem>, ListResponsePagination)>> getItems) where TRequest : ListRequestBase
        {
            var hasMoreContent = true;
            var pagination = ListPagination.WithPageAndSize(1, SverigesRadioApiDefaults.PageSizeWhenGetAll);
            while (hasMoreContent)
            {
                var result = await getItems(request, pagination);

                foreach (var item in result.Item1)
                {
                    yield return item;
                }

                hasMoreContent = result.Item2.HasMoreContent();
                if (hasMoreContent)
                {
                    pagination = result.Item2.GetNextPageListPagination();
                }
            }
        }
#endif
    }
}
