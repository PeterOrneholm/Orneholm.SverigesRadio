using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orneholm.SverigesRadio.Api.Models.Request;
using Orneholm.SverigesRadio.Api.Models.Request.Common;

namespace Orneholm.SverigesRadio.Api
{
    internal static class SverigesRadioUrlHelpers
    {
        private static readonly ListPagination DefaultPagination = ListPagination.FirstPage();

        public static void AddQueryStringParams<TRequest>(Dictionary<string, string?> queryStringParams, TRequest request, Action<TRequest, Dictionary<string, string?>> queryStringParamsResolver) where TRequest : ListRequestBase
        {
            queryStringParamsResolver?.Invoke(request, queryStringParams);
        }

        public static void AddPaginationQueryStringParams(Dictionary<string, string?> queryStringParams, ListPagination? pagination)
        {
            pagination ??= DefaultPagination;

            if (pagination.PaginationEnabled)
            {
                queryStringParams[Constants.Common.QueryString.PaginationEnabled] = Constants.Common.QueryString.True;

                if (pagination.PageNumber.HasValue)
                {
                    queryStringParams[Constants.Common.QueryString.PaginationPage] = pagination.PageNumber.Value.ToString("D");
                }

                if (pagination.PageSize.HasValue)
                {
                    queryStringParams[Constants.Common.QueryString.PaginationPageSize] = pagination.PageSize.Value.ToString("D");
                }
            }
            else
            {
                queryStringParams[Constants.Common.QueryString.PaginationEnabled] = Constants.Common.QueryString.False;
            }
        }

        public static void AddSortQueryStringParams<TSortField>(Dictionary<string, string?> queryStringParams, Func<TSortField, string>? sortFieldResolver, List<ListSort<TSortField>>? requestSort) where TSortField : Enum
        {
            if (requestSort == null || !requestSort.Any() || sortFieldResolver == null)
            {
                return;
            }

            var sortString = new StringBuilder();

            foreach (var sort in requestSort)
            {
                sortString.Append(sortFieldResolver.Invoke(sort.Field));

                if (sort.SortDesc)
                {
                    sortString.Append(Constants.Common.QueryString.SortDescSuffix);
                }

                sortString.Append(Constants.Common.QueryString.SortFieldSeparator);
            }

            queryStringParams[Constants.Common.QueryString.Sort] = sortString.ToString().TrimEnd(Constants.Common.QueryString.SortFieldSeparator);
        }

        public static void AddAudioSettingsQueryStringParams(Dictionary<string, string?> queryStringParams, AudioSettings audioSettings)
        {
            queryStringParams[Constants.Common.QueryString.AudioQuality] = GetAudioQuality(audioSettings.AudioQuality);

            if (audioSettings.LiveAudioTemplateId.HasValue)
            {
                queryStringParams[Constants.Common.QueryString.LiveAudioTemplateId] = audioSettings.LiveAudioTemplateId.Value.ToString("D");
            }
            if (audioSettings.OnDemandAudioTemplateId.HasValue)
            {
                queryStringParams[Constants.Common.QueryString.OnDemandAudioTemplateId] = audioSettings.OnDemandAudioTemplateId.Value.ToString("D");
            }
        }

        public static string GetAudioQuality(AudioQuality audioQuality)
        {
            return audioQuality switch
            {
                AudioQuality.Normal => Constants.Common.QueryString.AudioQualityNormal,
                AudioQuality.Low => Constants.Common.QueryString.AudioQualityLow,
                AudioQuality.High => Constants.Common.QueryString.AudioQualityHigh,

                _ => string.Empty
            };
        }
    }
}