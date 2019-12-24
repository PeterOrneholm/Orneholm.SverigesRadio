namespace Orneholm.SverigesRadio.Api.Models.Response.ProgramCategories
{
    public class ProgramCategoryDetailsResponse : DetailsResponseBase
    {
        public ProgramCategory ProgramCategory { get; set; } = new ProgramCategory();
    }
}
