using System.Threading.Tasks;
using Xunit;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public class ProgramCategories : TestsBase
    {
        [Fact]
        public async Task GetProgramCategory_Livsaskadning()
        {
            // Act
            var result = await ApiClient.GetProgramCategoryAsync(SampleIds.ProgramCategoryId_Livsaskadning);

            // Assert
            Assert.Equal(SampleIds.ProgramCategoryId_Livsaskadning, result.ProgramCategory.Id);
            Assert.Equal("Livsåskådning", result.ProgramCategory.Name);
        }


        [Fact]
        public async Task ListProgramCategories()
        {
            // Act
            var result = await ApiClient.ListProgramCategoriesAsync(pagination: FirstThreeItemsPagination);

            // Assert
            Assert.Equal(3, result.ProgramCategories.Count);
        }
    }
}
