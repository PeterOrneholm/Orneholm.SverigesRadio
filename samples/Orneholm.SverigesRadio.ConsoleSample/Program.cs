using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
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

            var apiClient = SverigesRadioApiClient.CreateClient();

            await ListProgramsSample(apiClient);
            await ListProgramCategoriesSample(apiClient);

            await GetEpisodesSample(apiClient);
            await SearchEpisodesSample(apiClient);

            await ListChannelsSample(apiClient);

            await ListExtraBroadcastsSample(apiClient);

            //await CreateConstants(apiClient);

            Console.WriteLine();
            Console.ReadLine();
        }

        private static async Task ListProgramsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListPrograms");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListProgramsAsync(new ProgramListRequest(), ListPagination.TakeFirst(5));
            var row = 1;
            foreach (var item in result.Programs)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id}): {item.Description}");

                Console.WriteLine("    GetLatestEpisode:");
                Console.WriteLine("    -------------------------"); var latestEpisode = await apiClient.GetLatestEpisodeAsync(new EpisodeLatestDetailsRequest(item.Id));
                Console.WriteLine($"    - {latestEpisode.Episode.PublishDateUtc}: {latestEpisode.Episode.Title} ({latestEpisode.Episode.Id}): {latestEpisode.Episode.Description}");

                Console.WriteLine("    ListEpisodes (latest 5):");
                Console.WriteLine("    -------------------------"); var episodes = await apiClient.ListEpisodesAsync(new EpisodeListRequest(item.Id), ListPagination.TakeFirst(5));
                foreach (var episode in episodes.Episodes)
                {
                    Console.WriteLine($"    - {episode.PublishDateUtc}: {episode.Title} ({episode.Id}): {episode.Description}");
                }

                Console.WriteLine("    ListBroadcasts (latest 5):");
                Console.WriteLine("    -------------------------");
                var broadcasts = await apiClient.ListBroadcastsAsync(new BroadcastListRequest(item.Id), ListPagination.TakeFirst(5));
                foreach (var broadcast in broadcasts.Broadcasts)
                {
                    Console.WriteLine($"    - {broadcast.BroadcastDateUtc}: {broadcast.Title} ({broadcast.Id}): {broadcast.Description}");
                }

                Console.WriteLine("    ListPodfiles (latest 5):");
                Console.WriteLine("    -------------------------");
                var podfiles = await apiClient.ListPodfilesAsync(new PodfileListRequest(item.Id), ListPagination.TakeFirst(5));
                foreach (var podfile in podfiles.Podfiles)
                {
                    Console.WriteLine($"    - {podfile.PublishDateUtc}: {podfile.Title} ({podfile.Id}): {podfile.Description}");
                }
            }
        }

        private static async Task SearchEpisodesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("SearchEpisodes");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.SearchEpisodesAsync(new EpisodeSearchRequest("Microsoft"), ListPagination.TakeFirst(5));
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

            var result = await apiClient.GetEpisodesAsync(new EpisodeDetailsMultipleRequest(new List<int>
            {
                1201209,
                1320251,
                410158,
            }), ListPagination.TakeFirst(5));
            var row = 1;
            foreach (var item in result.Episodes)
            {
                Console.WriteLine($"{row++}. {item.Title} ({item.Id}) - {item.Description}");
            }
        }

        private static async Task ListProgramCategoriesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListProgramCategories");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var items = apiClient.GetAllProgramCategoriesAsync(new ProgramCategoryListRequest());
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

            var items = apiClient.ListAllChannelsAsync(new ChannelListRequest());
            var row = 1;
            await foreach (var item in items)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id}): {item.ChannelType}");
            }
        }

        private static async Task ListExtraBroadcastsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ListExtraBroadcasts");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.ListExtraBroadcastsAsync(new ExtraBroadcastListRequest());
            var row = 1;
            foreach (var item in result.Broadcasts)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id})");
            }
        }



        private static async Task CreateConstants(SverigesRadioApiClient apiClient)
        {
            var items = apiClient.GetAllProgramCategoriesAsync(new ProgramCategoryListRequest());
            var sb = new StringBuilder();
            await foreach (var item in items)
            {
                sb.AppendLine($"public const int {item.Name.Replace(" ", "")} = {item.Id};");
            }

            Console.Write(sb.ToString());
        }
    }
}
