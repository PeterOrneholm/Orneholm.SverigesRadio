using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class AudioUrlTemplates : TestsBase
    {
        [Fact]
        public async Task ListOnDemandAudioTypes()
        {
            // Act
            var result = await ApiClient.ListOnDemandAudioTypesAsync();

            // Assert
            Assert.True(result.UrlTemplates.Any());
        }

        [Fact]
        public async Task ListLiveAudioTypes()
        {
            // Act
            var result = await ApiClient.ListLiveAudioTypesAsync();

            // Assert
            Assert.True(result.UrlTemplates.Any());
        }
    }
}