using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class ExtraBroadcasts : TestsBase
    {
        [Fact]
        public async Task ListExtraBroadcasts()
        {
            // Act
            var result = await ApiClient.ListExtraBroadcastsAsync(pagination: FirstOneItemPagination);

            // Assert
            Assert.Equal(1, result.Broadcasts.Count);
        }
    }
}
