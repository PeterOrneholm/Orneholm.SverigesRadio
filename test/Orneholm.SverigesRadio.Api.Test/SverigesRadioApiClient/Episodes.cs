using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class Episodes : TestsBase
    {
        [Fact]
        public async Task GetEpisode_Mojang()
        {
            // Act
            var result = await ApiClient.GetEpisodeAsync(SampleIds.EpisodeId_Mojang);

            // Assert
            Assert.Equal(SampleIds.EpisodeId_Mojang, result.Episode.Id);
        }

        [Fact]
        public async Task GetEpisodes_MojangAndMicrosoft()
        {
            // Act
            var result = await ApiClient.GetEpisodesAsync(new []
            {
                SampleIds.EpisodeId_MicrosoftDatacenter,
                SampleIds.EpisodeId_Mojang,
            }, ListPagination.Disabled());

            // Assert
            Assert.Equal(SampleIds.EpisodeId_MicrosoftDatacenter, result.Episodes[0].Id);
            Assert.Equal(2, result.Episodes.Count);
        }

        [Fact]
        public async Task GetLatestEpisode()
        {
            // Act
            var result = await ApiClient.GetLatestEpisodeAsync(SampleIds.ProgramId_Ekot);

            // Assert
            Assert.Equal(SampleIds.ProgramId_Ekot, result.Episode.Program.Id);
        }


        [Fact]
        public async Task ListEpisodes()
        {
            // Act
            var result = await ApiClient.ListEpisodesAsync(SampleIds.ProgramId_Ekot, pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(3, result.Episodes.Count);
            Assert.Equal(SampleIds.ProgramId_Ekot, result.Episodes[0].Program.Id);
        }

        [Fact]
        public async Task SearchEpisodes()
        {
            // Act
            var result = await ApiClient.SearchEpisodesAsync("Microsoft", pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(3, result.Episodes.Count);
        }

        [Fact]
        public async Task ListEpisodeNews()
        {
            // Act
            var result = await ApiClient.ListEpisodeNewsAsync();

            // Assert
            Assert.True(result.Episodes.Count > 0);
        }
    }
}