using System;
using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api
{
    internal class SverigesRadioApiListEndpointConfiguration<TRequest, TFilterField>
    {
        public SverigesRadioApiListEndpointConfiguration(string url, Action<TRequest, Dictionary<string, string?>>? queryStringParamsResolver = null, Func<TFilterField, string>? filterFieldResolver = null)
        {
            Url = url;
            QueryStringParamsResolver = queryStringParamsResolver;
            FilterFieldResolver = filterFieldResolver;
        }

        public string Url { get; }
        public Action<TRequest, Dictionary<string, string?>>? QueryStringParamsResolver { get; }
        public Func<TFilterField, string>? FilterFieldResolver { get; }
    }
}
