using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class Programs : TestsBase
    {
        [Fact]
        public async Task GetProgram_Ekot()
        {
            // Act
            var result = await ApiClient.GetProgramAsync(SampleIds.ProgramId_Ekot);

            // Assert
            Assert.Equal(SampleIds.ProgramId_Ekot, result.Program.Id);
            Assert.Equal("Ekot", result.Program.Name);
        }


        [Fact]
        public async Task ListPrograms()
        {
            // Act
            var result = await ApiClient.ListProgramsAsync(pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(3, result.Programs.Count);
        }

        [Fact]
        public async Task ListProgramNews()
        {
            // Act
            var result = await ApiClient.ListProgramNewsAsync();

            // Assert
            Assert.True(result.Programs.Any());
        }
    }
}
