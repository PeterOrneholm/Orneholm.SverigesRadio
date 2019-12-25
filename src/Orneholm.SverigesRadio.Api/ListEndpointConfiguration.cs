using System;
using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api
{
    internal class ListEndpointConfiguration<TRequest>
    {
        public ListEndpointConfiguration(string url, Action<TRequest, Dictionary<string, string?>>? queryStringParamsResolver = null)
        {
            Url = url;
            QueryStringParamsResolver = queryStringParamsResolver;
        }

        public string Url { get; }
        public Action<TRequest, Dictionary<string, string?>>? QueryStringParamsResolver { get; }
    }
}
