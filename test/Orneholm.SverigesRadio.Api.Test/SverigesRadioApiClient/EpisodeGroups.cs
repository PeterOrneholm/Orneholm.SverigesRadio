using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class EpisodeGroups : TestsBase
    {
        [Fact]
        public async Task ListEpisodeGroups()
        {
            // Act
            var result = await ApiClient.ListEpisodeGroupsAsync(SampleIds.EpisodeGroupId_Dokumentarer, pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(SampleIds.EpisodeGroupId_Dokumentarer, result.EpisodeGroup.Id);
            Assert.Equal("Dokumentärer om kända kriminalfall ", result.EpisodeGroup.Title);
            Assert.Equal(3, result.EpisodeGroup.Episodes.Count);
        }
    }
}
