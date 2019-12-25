using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class Broadcasts : TestsBase
    {
        [Fact]
        public async Task ListBroadcasts()
        {
            // Act
            var result = await ApiClient.ListBroadcastsAsync(SampleIds.ProgramId_Ekot, pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(3, result.Broadcasts.Count);
        }
    }
}
