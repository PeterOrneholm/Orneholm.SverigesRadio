namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public abstract class DetailsRequestBase : RequestBase
    {
        protected DetailsRequestBase(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
