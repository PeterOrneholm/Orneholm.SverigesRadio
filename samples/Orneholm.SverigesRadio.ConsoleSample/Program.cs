using System;
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

            await GetProgramsSample(apiClient);
            await GetProgramCategoriesSample(apiClient);

            await GetChannelsSample(apiClient);

            //await CreateConstants(apiClient);

            Console.WriteLine();
            Console.ReadLine();
        }

        private static async Task GetProgramsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("Programs");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var result = await apiClient.GetProgramsAsync(new ProgramListRequest(), ListPagination.TakeFirst(5));
            var row = 1;
            foreach (var item in result.Programs)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id}): {item.Description}");

                Console.WriteLine("    Episodes (latest 5):");
                Console.WriteLine("    -------------------------"); var episodes = await apiClient.GetEpisodesAsync(new EpisodeListRequest(item.Id), ListPagination.TakeFirst(5));
                foreach (var episode in episodes.Episodes)
                {
                    Console.WriteLine($"    - {episode.PublishDateUtc}: {episode.Title} ({episode.Id}): {episode.Description}");
                }

                Console.WriteLine("    Broadcasts (latest 5):");
                Console.WriteLine("    -------------------------");
                var broadcasts = await apiClient.GetBroadcastsAsync(new BroadcastListRequest(item.Id), ListPagination.TakeFirst(5));
                foreach (var broadcast in broadcasts.Broadcasts)
                {
                    Console.WriteLine($"    - {broadcast.BroadcastDateUtc}: {broadcast.Title} ({broadcast.Id}): {broadcast.Description}");
                }

                Console.WriteLine("    Podfiles (latest 5):");
                Console.WriteLine("    -------------------------");
                var podfiles = await apiClient.GetPodfilesAsync(new PodfileListRequest(item.Id), ListPagination.TakeFirst(5));
                foreach (var podfile in podfiles.Podfiles)
                {
                    Console.WriteLine($"    - {podfile.PublishDateUtc}: {podfile.Title} ({podfile.Id}): {podfile.Description}");
                }
            }
        }

        private static async Task GetProgramCategoriesSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("ProgramCategories");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var items = apiClient.GetAllProgramCategoriesAsync(new ProgramCategoryListRequest());
            var row = 1;
            await foreach (var item in items)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id})");
            }
        }

        private static async Task GetChannelsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine();
            Console.WriteLine("Channels");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var items = apiClient.GetAllChannelsAsync(new ChannelListRequest());
            var row = 1;
            await foreach (var item in items)
            {
                Console.WriteLine($"{row++}. {item.Name} ({item.Id}): {item.ChannelType}");
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
