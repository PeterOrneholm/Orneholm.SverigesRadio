namespace Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories
{
    public class ProgramCategoryDetailsRequest : DetailsRequestBase
    {
        /// <param name="id">Programkategoriid</param>
        public ProgramCategoryDetailsRequest(int id)
        : base(id)
        {
        }
    }
}
