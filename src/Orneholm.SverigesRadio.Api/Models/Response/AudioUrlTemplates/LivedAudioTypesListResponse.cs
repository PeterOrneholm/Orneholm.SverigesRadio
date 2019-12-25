using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api.Models.Response.AudioUrlTemplates
{
    public class LivedAudioTypesListResponse : ResponseBase
    {
        public List<AudioUrlTemplate> UrlTemplates { get; set; } = new List<AudioUrlTemplate>();
    }
}