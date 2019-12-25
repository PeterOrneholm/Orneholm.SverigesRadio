namespace Orneholm.SverigesRadio.Api.Models.Request.Channels
{
    public class ChannelDetailsRequest : DetailsRequestBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Kanal id.</param>
        public ChannelDetailsRequest(int id)
        : base(id)
        {
        }
    }
}
