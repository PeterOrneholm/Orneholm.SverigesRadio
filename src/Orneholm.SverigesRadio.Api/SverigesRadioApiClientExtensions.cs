using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.AudioUrlTemplates;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.ExtraBroadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Orneholm.SverigesRadio.Api.Models.Response;
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
    public static class SverigesRadioApiClientExtensions
    {
#if NETSTANDARD2_1

        public static IAsyncEnumerable<Program> ListAllProgramsAsync(this ISverigesRadioApiClient apiClient, int? channelId, int? programCategoryId = null)
        {
            return apiClient.ListAllProgramsAsync(new ProgramListRequest
            {
                ChannelId = channelId,
                ProgramCategoryId = programCategoryId
            });
        }

        public static IAsyncEnumerable<Program> ListAllProgramsAsync(this ISverigesRadioApiClient apiClient, ProgramListRequest request)
        {
            return apiClient.ListAllAsync<Program, ProgramListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListProgramsAsync(request, pagination);
                return (result.Programs, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Models.Response.ProgramCategories.ProgramCategory> ListAllProgramCategoriesAsync(this ISverigesRadioApiClient apiClient)
        {
            return apiClient.ListAllProgramCategoriesAsync(new ProgramCategoryListRequest());
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

        public static IAsyncEnumerable<Episode> SearchAllEpisodesAsync(this ISverigesRadioApiClient apiClient, string searchQuery, int? programId = null, int? channelId = null)
        {
            if (searchQuery == null)
            {
                throw new ArgumentNullException(nameof(searchQuery));
            }

            return apiClient.SearchAllEpisodesAsync(new EpisodeSearchRequest(searchQuery)
            {
                ProgramId = programId,
                ChannelId = channelId
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

        public static IAsyncEnumerable<EpisodeGroupEpisode> ListAllEpisodeGroupsAsync(this ISverigesRadioApiClient apiClient, int groupId)
        {
            return apiClient.ListAllEpisodeGroupsAsync(new EpisodeGroupListRequest(groupId));
        }

        public static IAsyncEnumerable<EpisodeGroupEpisode> ListAllEpisodeGroupsAsync(this ISverigesRadioApiClient apiClient, EpisodeGroupListRequest request)
        {
            return apiClient.ListAllAsync<EpisodeGroupEpisode, EpisodeGroupListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListEpisodeGroupsAsync(request, pagination);
                return (result.EpisodeGroup.Episodes, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Channel> ListAllChannelsAsync(this ISverigesRadioApiClient apiClient)
        {
            return apiClient.ListAllChannelsAsync(new ChannelListRequest());
        }

        public static IAsyncEnumerable<Channel> ListAllChannelsAsync(this ISverigesRadioApiClient apiClient, ChannelListRequest request)
        {
            return apiClient.ListAllAsync<Channel, ChannelListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListChannelsAsync(request, pagination);
                return (result.Channels, result.Pagination);
            });
        }

        public static IAsyncEnumerable<Broadcast> ListAllBroadcastsAsync(this ISverigesRadioApiClient apiClient, int programId)
        {
            return apiClient.ListAllBroadcastsAsync(new BroadcastListRequest(programId));
        }

        public static IAsyncEnumerable<Broadcast> ListAllBroadcastsAsync(this ISverigesRadioApiClient apiClient, BroadcastListRequest request)
        {
            return apiClient.ListAllAsync<Broadcast, BroadcastListRequest>(request, async (listRequest, pagination) =>
            {
                var result = await apiClient.ListBroadcastsAsync(request, pagination);
                return (result.Broadcasts, result.Pagination);
            });
        }

        public static IAsyncEnumerable<ExtraBroadcast> ListAllExtraBroadcastsAsync(this ISverigesRadioApiClient apiClient, DateTime? date = null)
        {
            return apiClient.ListAllExtraBroadcastsAsync(new ExtraBroadcastListRequest
            {
                Date = date
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

        public static IAsyncEnumerable<Podfile> ListAllPodfilesAsync(this ISverigesRadioApiClient apiClient, int programId)
        {
            return apiClient.ListAllPodfilesAsync(new PodfileListRequest(programId));
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


        // Programs

        public static Task<ProgramDetailsResponse> GetProgramAsync(this ISverigesRadioApiClient apiClient, int id)
        {
            return apiClient.GetProgramAsync(new ProgramDetailsRequest(id));
        }

        public static Task<ProgramListResponse> ListProgramsAsync(this ISverigesRadioApiClient apiClient, int? channelId = null, int? programCategoryId = null, ListPagination? pagination = null)
        {
            return apiClient.ListProgramsAsync(new ProgramListRequest
            {
                ChannelId = channelId,
                ProgramCategoryId = programCategoryId
            }, pagination);
        }

        public static Task<ProgramNewsListResponse> ListProgramNewsAsync(this ISverigesRadioApiClient apiClient)
        {
            return apiClient.ListProgramNewsAsync(new ProgramNewsListRequest());
        }

        // ProgramCategories

        public static Task<ProgramCategoryDetailsResponse> GetProgramCategoryAsync(this ISverigesRadioApiClient apiClient, int id)
        {
            return apiClient.GetProgramCategoryAsync(new ProgramCategoryDetailsRequest(id));
        }

        public static Task<ProgramCategoryListResponse> ListProgramCategoriesAsync(this ISverigesRadioApiClient apiClient, ListPagination? pagination = null)
        {
            return apiClient.ListProgramCategoriesAsync(new ProgramCategoryListRequest(), pagination);
        }

        // Channels

        public static Task<ChannelDetailsResponse> GetChannelAsync(this ISverigesRadioApiClient apiClient, int id)
        {
            return apiClient.GetChannelAsync(new ChannelDetailsRequest(id));
        }

        public static Task<ChannelListResponse> ListChannelsAsync(this ISverigesRadioApiClient apiClient, ListPagination? pagination = null)
        {
            return apiClient.ListChannelsAsync(new ChannelListRequest(), pagination);
        }

        // Episodes

        public static Task<EpisodeDetailsResponse> GetEpisodeAsync(this ISverigesRadioApiClient apiClient, int id)
        {
            return apiClient.GetEpisodeAsync(new EpisodeDetailsRequest(id));
        }

        public static Task<EpisodeListResponse> GetEpisodesAsync(this ISverigesRadioApiClient apiClient, IEnumerable<int> ids, ListPagination? pagination = null)
        {
            return apiClient.GetEpisodesAsync(new EpisodeDetailsMultipleRequest(ids.ToList()), pagination);
        }

        public static Task<EpisodeDetailsResponse> GetLatestEpisodeAsync(this ISverigesRadioApiClient apiClient, int programId)
        {
            return apiClient.GetLatestEpisodeAsync(new EpisodeLatestDetailsRequest(programId));
        }

        public static Task<EpisodeListResponse> ListEpisodesAsync(this ISverigesRadioApiClient apiClient, int programId, DateTime? fromDate = null, DateTime? toDate = null, ListPagination? pagination = null)
        {
            return apiClient.ListEpisodesAsync(new EpisodeListRequest(programId)
            {
                FromDate = fromDate,
                ToDate = toDate
            }, pagination);
        }

        public static Task<EpisodeListResponse> SearchEpisodesAsync(this ISverigesRadioApiClient apiClient, string searchQuery, int? programId = null, int? chanelId = null, ListPagination? pagination = null)
        {
            if (searchQuery == null)
            {
                throw new ArgumentNullException(nameof(searchQuery));
            }

            return apiClient.SearchEpisodesAsync(new EpisodeSearchRequest(searchQuery)
            {
                ProgramId = programId,
                ChannelId = chanelId
            }, pagination);
        }

        public static Task<EpisodeNewsListResponse> ListEpisodeNewsAsync(this ISverigesRadioApiClient apiClient)
        {
            return apiClient.ListEpisodeNewsAsync(new EpisodeNewsListRequest());
        }

        // EpisodeGroups

        public static Task<EpisodeGroupListResponse> ListEpisodeGroupsAsync(this ISverigesRadioApiClient apiClient, int groupId, ListPagination? pagination = null)
        {
            return apiClient.ListEpisodeGroupsAsync(new EpisodeGroupListRequest(groupId), pagination);
        }

        // Broadcasts

        public static Task<BroadcastListResponse> ListBroadcastsAsync(this ISverigesRadioApiClient apiClient, int programId, ListPagination? pagination = null)
        {
            return apiClient.ListBroadcastsAsync(new BroadcastListRequest(programId), pagination);
        }

        public static Task<ExtraBroadcastListResponse> ListExtraBroadcastsAsync(this ISverigesRadioApiClient apiClient, DateTime? date = null, ListPagination? pagination = null)
        {
            return apiClient.ListExtraBroadcastsAsync(new ExtraBroadcastListRequest
            {
                Date = date
            }, pagination);
        }

        // Podfiles

        public static Task<PodfileDetailsResponse> GetPodfileAsync(this ISverigesRadioApiClient apiClient, int id)
        {
            return apiClient.GetPodfileAsync(new PodfileDetailsRequest(id));
        }

        public static Task<PodfileListResponse> ListPodfilesAsync(this ISverigesRadioApiClient apiClient, int programId, ListPagination? pagination = null)
        {
            return apiClient.ListPodfilesAsync(new PodfileListRequest(programId), pagination);
        }

        // AudioUrlTemplates

        public static Task<OnDemandAudioTypesListResponse> ListOnDemandAudioTypesAsync(this ISverigesRadioApiClient apiClient)
        {
            return apiClient.ListOnDemandAudioTypesAsync(new OnDemandAudioTypesListRequest());
        }

        public static Task<LivedAudioTypesListResponse> ListLiveAudioTypesAsync(this ISverigesRadioApiClient apiClient)
        {
            return apiClient.ListLiveAudioTypesAsync(new LiveAudioTypesListRequest());
        }
    }
}
