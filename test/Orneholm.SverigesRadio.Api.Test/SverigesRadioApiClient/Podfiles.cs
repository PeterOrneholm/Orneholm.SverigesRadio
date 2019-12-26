using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class Podfiles : TestsBase
    {
        [Fact]
        public async Task GetProgramCategory_Ekot191225()
        {
            // Act
            var result = await ApiClient.GetPodfileAsync(SampleIds.PodfileId_Ekot191225);

            // Assert
            Assert.Equal(SampleIds.PodfileId_Ekot191225, result.Podfile.Id);
            Assert.Equal("Nyheter från Ekot 20191225 22:00", result.Podfile.Title);
        }


        [Fact]
        public async Task ListPodfiles()
        {
            // Act
            var result = await ApiClient.ListPodfilesAsync(SampleIds.ProgramId_Ekot, pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(3, result.Podfiles.Count);
            Assert.Equal(SampleIds.ProgramId_Ekot, result.Podfiles[0].Program.Id);
        }
    }
}
