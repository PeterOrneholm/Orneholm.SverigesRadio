using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class Channels : TestsBase
    {
        [Fact]
        public async Task GetChannel_P4_Ostergötland()
        {
            // Act
            var result = await ApiClient.GetChannelAsync(SampleIds.ChannelId_P4_Ostergötland);

            // Assert
            Assert.Equal(SampleIds.ChannelId_P4_Ostergötland, result.Channel.Id);
            Assert.Equal("P4 Östergötland", result.Channel.Name);
        }


        [Fact]
        public async Task ListChannels()
        {
            // Act
            var result = await ApiClient.ListChannelsAsync(pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(3, result.Channels.Count);
        }
    }
}