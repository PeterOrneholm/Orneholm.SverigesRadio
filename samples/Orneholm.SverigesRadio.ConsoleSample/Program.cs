using System;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

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

            Console.WriteLine();
            Console.WriteLine("List programs:");
            var programsResult = await apiClient.ListProgramsAsync();
            foreach (var program in programsResult.Programs)
            {
                Console.WriteLine($"{program.Name} ({program.Id}): {program.Description}");
            }

            Console.WriteLine();
            Console.WriteLine("Get latest episode for P3 Dokumentär:");
            var episodeResult = await apiClient.GetLatestEpisodeAsync(SverigesRadioApiIds.Programs.P3_Dokumentar);
            Console.WriteLine($"{episodeResult.Episode.Title} ({episodeResult.Episode.Id}): {episodeResult.Episode.Description}");

            Console.WriteLine();
            Console.WriteLine("List podfiles for Så funkar det (last 3):");
            var podfilesResult = await apiClient.ListPodfilesAsync(SverigesRadioApiIds.Programs.Sa_Funkar_Det, ListPagination.TakeFirst(5));
            foreach (var podfile in podfilesResult.Podfiles)
            {
                Console.WriteLine($"{podfile.Title} ({podfile.Id}): {podfile.Url}");
            }

            Console.WriteLine();
            Console.WriteLine("Search episodes:");
            var episodeSearchResult = await apiClient.SearchEpisodesAsync("Microsoft");
            foreach (var episode in episodeSearchResult.Episodes)
            {
                Console.WriteLine($"{episode.Title} ({episode.Id}) - {episode.Description}");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
