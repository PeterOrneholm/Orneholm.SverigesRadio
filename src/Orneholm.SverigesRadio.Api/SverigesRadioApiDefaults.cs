using System;

namespace Orneholm.SverigesRadio.Api
{
    public static class SverigesRadioApiDefaults
    {
        public const int PageSize = 10;
        public const int PageSizeWhenGetAll = 100;

        /// <summary>
        /// Base url for production API.
        /// </summary>
        public static readonly Uri ProductionApiBaseUrl = new Uri("https://api.sr.se/api/v2/");
    }
}
