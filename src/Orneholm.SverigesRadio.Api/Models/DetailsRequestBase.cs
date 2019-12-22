namespace Orneholm.SverigesRadio.Api.Models
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
