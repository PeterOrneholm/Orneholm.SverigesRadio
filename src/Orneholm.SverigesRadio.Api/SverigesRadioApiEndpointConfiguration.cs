using System;
using System.Collections.Generic;

namespace Orneholm.SverigesRadio.Api
{
    internal class SverigesRadioApiEndpointConfiguration<TRequest, TFilterField, TSortField>
    {
        public SverigesRadioApiEndpointConfiguration(string url, Action<TRequest, Dictionary<string, string?>> queryStringParamsResolver, Func<TFilterField, string>? filterFieldResolver, Func<TSortField, string>? sortFieldResolver)
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
