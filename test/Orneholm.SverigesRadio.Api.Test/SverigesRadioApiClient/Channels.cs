using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class Channels : TestsBase
    {
        [Fact]
        public async Task GetChannel_P4_Osterg�tland()
        {
            // Act
            var result = await ApiClient.GetChannelAsync(SampleIds.ChannelId_P4_Osterg�tland);

            // Assert
            Assert.Equal(SampleIds.ChannelId_P4_Osterg�tland, result.Channel.Id);
            Assert.Equal("P4 �sterg�tland", result.Channel.Name);
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