using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.AudioUrlTemplates;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Common;
using Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.ExtraBroadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;

namespace Orneholm.SverigesRadio.ConsoleSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Orneholm.SverigesRadio.ConsoleSample");
            Console.WriteLine("########################################################");
            Console.WriteLine();

            var apiClient = SverigesRadioApiClient.CreateClient(new AudioSettings
            {
                OnDemandAudioTemplateId = SverigesRadioApiIds.OnDemandAudioTemplates.Html5_Desktop,
                LiveAudioTemplateId = SverigesRadioApiIds.LiveAudioTemplates.MP3,

                AudioQuality = AudioQuality.High
            });

            await ListProgramsSample(apiClient);
            await ListProgramNewsSample(apiClient);
            await ListProgramCategoriesSample(apiClient);

            await GetEpisodesSample(apiClient);
            await SearchEpisodesSample(apiClient);

            await ListEpisodeNewsSample(apiClient);
            await ListEpisodeGroupsSample(apiClient);

            await ListChannelsSample(apiClient);

            await ListExtraBroadcastsSample(apiClient);

            await ListOnDemandAudioTypesSample(apiClient);
            await ListLiveAudioTypesSample(apiClient);

            Console.WriteLine();
            Console.ReadLine();
        }

        private static async Task ListProgramsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListPrograms");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListProgramsAsync(pagination: ListPagination.TakeFirst(3));
            var row = 1;
            foreach (var item in result.Programs)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id}): {item.Description}");

                Console.WriteLine();
                Console.WriteLine("    GetLatestEpisode:");
                Console.WriteLine("    -------------------------"); var latestEpisode = await apiClient.GetLatestEpisodeAsync(item.Id);
                Console.WriteLine($"    - {latestEpisode.Episode.PublishDateUtc}: {latestEpisode.Episode.Title} ({latestEpisode.Episode.Id}): {latestEpisode.Episode.Description}");

                Console.WriteLine();
                Console.WriteLine("    ListEpisodes (latest 5):");
                Console.WriteLine("    -------------------------"); var episodes = await apiClient.ListEpisodesAsync(item.Id, pagination: ListPagination.TakeFirst(5));
                foreach (var episode in episodes.Episodes)
                {
                    Console.WriteLine($"    - {episode.PublishDateUtc}: {episode.Title} ({episode.Id}): {episode.Description}");
                }

                Console.WriteLine();
                Console.WriteLine("    ListBroadcasts (latest 5):");
                Console.WriteLine("    -------------------------");
                var broadcasts = await apiClient.ListBroadcastsAsync(item.Id, ListPagination.TakeFirst(5));
                foreach (var broadcast in broadcasts.Broadcasts)
                {
                    Console.WriteLine($"    - {broadcast.BroadcastDateUtc}: {broadcast.Title} ({broadcast.Id}): {broadcast.Description}");
                }

                Console.WriteLine();
                Console.WriteLine("    ListPodfiles (latest 5):");
                Console.WriteLine("    -------------------------");
                var podfiles = await apiClient.ListPodfilesAsync(item.Id, ListPagination.TakeFirst(5));
                foreach (var podfile in podfiles.Podfiles)
                {
                    Console.WriteLine($"    - {podfile.PublishDateUtc}: {podfile.Title} ({podfile.Id}): {podfile.Description}");
                }
            }
        }

        private static async Task ListProgramNewsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListProgramNews");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListProgramNewsAsync();
            var row = 1;
            foreach (var item in result.Programs)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id}) - {item.Description}");
            }
        }

        private static async Task SearchEpisodesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("SearchEpisodes");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.SearchEpisodesAsync("Microsoft", pagination: ListPagination.TakeFirst(5));
            var row = 1;
            foreach (var item in result.Episodes)
            {
                Console.WriteLine($"{row++}. {item.Title} ({item.Id}) - {item.Description}");
            }
        }

        private static async Task GetEpisodesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("GetEpisodes");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.GetEpisodesAsync(new []
            {
                1201209,
                1320251,
                410158,
            });
            var row = 1;
            foreach (var item in result.Episodes)
            {
                Console.WriteLine($"{row++}. {item.Title} ({item.Id}) - {item.Description}");
            }
        }

        private static async Task ListEpisodeNewsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListEpisodeNews");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListEpisodeNewsAsync();
            var row = 1;
            foreach (var item in result.Episodes)
            {
                Console.WriteLine($"{row++}. {item.Title} ({item.Id}) - {item.Description}");
            }
        }

        private static async Task ListEpisodeGroupsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListEpisodeGroups");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListEpisodeGroupsAsync(23037, ListPagination.TakeFirst(5));
            var row = 1;

            Console.WriteLine($"{result.EpisodeGroup.Title} ({result.EpisodeGroup.Id}) - {result.EpisodeGroup.Description}");

            Console.WriteLine();
            Console.WriteLine("    Episodes (latest 5):");
            Console.WriteLine("    -------------------------");
            foreach (var item in result.EpisodeGroup.Episodes)
            {
                Console.WriteLine($"{row++}. {item.Title} ({item.Id}): {item.Description}");
            }
        }

        private static async Task ListProgramCategoriesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListProgramCategories");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var items = apiClient.ListAllProgramCategoriesAsync();
            var row = 1;
            await foreach (var item in items)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id})");
            }
        }

        private static async Task ListChannelsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListChannels");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var items = apiClient.ListAllChannelsAsync();
            var row = 1;
            await foreach (var item in items)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id}): {item.ChannelType}");
            }
        }

        private static async Task ListOnDemandAudioTypesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListOnDemandAudioTypes");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListOnDemandAudioTypesAsync();
            var row = 1;
            foreach (var item in result.UrlTemplates)
            {
                Console.WriteLine($"{row++}. {item.Url} ({item.Id})");
            }
        }

        private static async Task ListLiveAudioTypesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListLiveAudioTypes");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListLiveAudioTypesAsync();
            var row = 1;
            foreach (var item in result.UrlTemplates)
            {
                Console.WriteLine($"{row++}. {item.Url} ({item.Id})");
            }
        }

        private static async Task ListExtraBroadcastsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListExtraBroadcasts");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListExtraBroadcastsAsync();
            var row = 1;
            foreach (var item in result.Broadcasts)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id})");
            }
        }
    }
}
