using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response;
using Orneholm.SverigesRadio.Api.Models.Response.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Response.Channels;
using Orneholm.SverigesRadio.Api.Models.Response.Episodes;
using Orneholm.SverigesRadio.Api.Models.Response.Programs;

namespace Orneholm.SverigesRadio.Api
{
    /// <summary>
    /// Extensions to enable easier access to common api scenarios.
    /// </summary>
    public static class SverigesRadioApiClientExtensions
    {
#if NETSTANDARD2_1
        public static IAsyncEnumerable<Program> GetAllProgramsAsync(this ISverigesRadioApiClient apiClient, ProgramListRequest request)
        {
            return apiClient.GetAllAsync<Program, ProgramListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.GetProgramsAsync(request, pagination);
                return (result.Programs, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Models.Response.ProgramCategories.ProgramCategory> GetAllProgramCategoriesAsync(this ISverigesRadioApiClient apiClient, ProgramCategoryListRequest request)
        {
            return apiClient.GetAllAsync<Models.Response.ProgramCategories.ProgramCategory, ProgramCategoryListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.GetProgramCategoriesAsync(request, pagination);
                return (result.ProgramCategories, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Episode> GetAllProgramCategoriesAsync(this ISverigesRadioApiClient apiClient, EpisodeListRequest request)
        {
            return apiClient.GetAllAsync<Episode, EpisodeListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.GetEpisodesAsync(request, pagination);
                return (result.Episodes, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Channel> GetAllChannelsAsync(this ISverigesRadioApiClient apiClient, ChannelListRequest request)
        {
            return apiClient.GetAllAsync<Channel, ChannelListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.GetChannelsAsync(request, pagination);
                return (result.Channels, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Broadcast> GetAllBroadcastsAsync(this ISverigesRadioApiClient apiClient, BroadcastListRequest request)
        {
            return apiClient.GetAllAsync<Broadcast, BroadcastListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.GetBroadcastsAsync(request, pagination);
                return (result.Broadcasts, result.Pagination);
            });
        }

        private static async IAsyncEnumerable<TItem> GetAllAsync<TItem, TRequest>(this ISverigesRadioApiClient apiClient, TRequest request, Func<TRequest, ListPagination, Task<(IEnumerable<TItem>, ListResponsePagination)>> getItems) where TRequest : ListRequestBase
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
