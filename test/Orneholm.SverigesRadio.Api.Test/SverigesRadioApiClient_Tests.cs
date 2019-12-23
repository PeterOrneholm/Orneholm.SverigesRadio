using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test
{
    public class SverigesRadioApiClient_Tests
    {
        private readonly SverigesRadioApiClient _apiClient;

        public SverigesRadioApiClient_Tests()
        {
            _apiClient = SverigesRadioApiClient.CreateClient(SverigesRadioUrls.ProductionApiBaseUrl);
        }

        [Fact]
        public async Task GetProgram_For4540_Should_Return_Ekot()
        {
            // Arrange
            var request = new ProgramDetailsRequest(4540);

            // Act
            var result = await _apiClient.GetProgramAsync(request);

            // Assert
            Assert.Equal(4540, result.Program.Id);
            Assert.Equal("Ekot", result.Program.Name);
        }


        [Fact]
        public async Task GetPrograms_Should_Return_Programs()
        {
            // Arrange
            var request = new ProgramListRequest();
            var pagination = ListPagination.WithPageAndSize(1, 10);

            // Act
            var result = await _apiClient.GetProgramsAsync(request, pagination);

            // Assert
            Assert.Equal(10, result.Programs.Count);
        }
    }
}
