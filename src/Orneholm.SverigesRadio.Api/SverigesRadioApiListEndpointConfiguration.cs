using System;
using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api
{
    internal class SverigesRadioApiListEndpointConfiguration<TRequest, TFilterField, TSortField>
    {
        public SverigesRadioApiListEndpointConfiguration(string url, Action<TRequest, Dictionary<string, string?>> queryStringParamsResolver, Func<TFilterField, string>? filterFieldResolver = null, Func<TSortField, string>? sortFieldResolver = null)
        {
            Url = url;
            QueryStringParamsResolver = queryStringParamsResolver;
            FilterFieldResolver = filterFieldResolver;
            SortFieldResolver = sortFieldResolver;
        }

        public string Url { get; }
        public Action<TRequest, Dictionary<string, string?>> QueryStringParamsResolver { get; }
        public Func<TFilterField, string>? FilterFieldResolver { get; }
        public Func<TSortField, string>? SortFieldResolver { get; }
    }
}
