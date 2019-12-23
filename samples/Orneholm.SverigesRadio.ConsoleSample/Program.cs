using System;
using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api;
using Orneholm.SverigesRadio.Api.Models;
using Orneholm.SverigesRadio.Api.Models.Request;
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
            await GetChannelsSample(apiClient);

            Console.WriteLine();
            Console.ReadLine();
        }

        private static async Task GetProgramsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine("Programs");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var programs = await apiClient.GetProgramsAsync(new ProgramListRequest());

            foreach (var program in programs.Programs)
            {
                Console.WriteLine($"{program.Name} ({program.Id}): {program.Description}");
            }
        }

        private static async Task GetChannelsSample(SverigesRadioApiClient apiClient)
        {
            Console.WriteLine("Channels");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            var programs = await apiClient.GetChannelsAsync(new ChannelListRequest());

            foreach (var program in programs.Channels)
            {
                Console.WriteLine($"{program.Name} ({program.Id}): {program.ChannelType}");
            }
        }
    }
}
