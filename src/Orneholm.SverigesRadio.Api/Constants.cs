using System.Linq;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.Podfiles;
using Orneholm.SverigesRadio.Api.Models.Request.ProgramCategories;
using Orneholm.SverigesRadio.Api.Models.Request.Programs;

namespace Orneholm.SverigesRadio.Api
{
    internal static class Constants
    {
        public static class Common
        {
            public static class QueryString
            {
                // Boolean
                public const string True = "true";
                public const string False = "false";

                // Format
                public const string Format = "format";
                public const string FormatJson = "json";

                // Indent
                public const string Indent = "indent";

                // Pagnation
                public const string PaginationEnabled = "pagination";
                public const string PaginationPage = "page";
                public const string PaginationPageSize = "size";

                // Sort
                public const string Sort = "sort";
                public const string SortDescSuffix = "+desc";
                public const char SortFieldSeparator = ',';

                // Filter
                public const string FilterField = "filter";
                public const string FilterValue = "filtervalue";

                // Audio
                public const string AudioQuality = "audioquality";
                public const string AudioQualityLow = "lo";
                public const string AudioQualityNormal = "normal";
                public const string AudioQualityHigh = "hi";

                public const string LiveAudioTemplateId = "liveaudiotemplateid";
                public const string OnDemandAudioTemplateId = "ondemandaudiotemplateid";
            }
        }

        public static class Programs
        {
            public const string BaseUrl = "programs";

            public static readonly SverigesRadioApiListEndpointConfiguration<ProgramListRequest, ProgramListFilterFields, ProgramListSortFields> ListEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<ProgramListRequest, ProgramListFilterFields, ProgramListSortFields>(
                BaseUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.ChannelId] = request.ChannelId?.ToString("D");
                    queryString[QueryString.ProgramCategoryId] = request.ProgramCategoryId?.ToString("D");
                    queryString[QueryString.IsArchived] = request.IsArchived?.ToString().ToLower();
                },
                fields =>
                {
                    return fields switch
                    {
                        ProgramListFilterFields.Archived => Filter.Archived,
                        ProgramListFilterFields.HasOnDemand => Filter.HasOnDemand,
                        ProgramListFilterFields.HasPod => Filter.HasPod,
                        ProgramListFilterFields.ResponsibleEditor => Filter.ResponsibleEditor,

                        _ => string.Empty
                    };
                }
            );

            public static class QueryString
            {
                public const string ChannelId = "channelid";
                public const string ProgramCategoryId = "programcategoryid";
                public const string IsArchived = "isarchived";
            }

            public static class Filter
            {
                public const string Archived = "program.archived";
                public const string HasOnDemand = "program.hasondemand";
                public const string HasPod = "program.haspod";
                public const string ResponsibleEditor = "program.responsibleeditor";
            }
        }

        public static class ProgramCategories
        {
            public const string BaseUrl = "programcategories";

            public static readonly SverigesRadioApiListEndpointConfiguration<ProgramCategoryListRequest, ProgramCategoryListFilterFields, ProgramCategorySortFields> ListEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<ProgramCategoryListRequest, ProgramCategoryListFilterFields, ProgramCategorySortFields>(
                BaseUrl
            );
        }

        public static class Channels
        {
            public const string BaseUrl = "channels";

            public static readonly SverigesRadioApiListEndpointConfiguration<ChannelListRequest, ChannelListFilterFields, ChannelListSortFields> ListEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<ChannelListRequest, ChannelListFilterFields, ChannelListSortFields>(
                BaseUrl,
                (request, queryString) => { },
                fields =>
                {
                    return fields switch
                    {
                        ChannelListFilterFields.ChannelType => Filter.ChannelType,

                        _ => string.Empty
                    };
                }
            );

            public static class Filter
            {
                public const string ChannelType = "channel.channeltype";
            }
        }


        public static class Episodes
        {
            public const string BaseUrl = "episodes";
            public const string SearchUrl = BaseUrl + "/search";
            public const string GetMultipleUrl = BaseUrl + "/getlist";

            public static readonly SverigesRadioApiListEndpointConfiguration<EpisodeListRequest, EpisodeListFilterFields, EpisodeListSortFields> ListEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<EpisodeListRequest, EpisodeListFilterFields, EpisodeListSortFields>(
                BaseUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.ProgramId] = request.ProgramId.ToString("D");

                    if (request.FromDate.HasValue)
                    {
                        queryString[QueryString.FromDate] = request.FromDate.Value.Date.ToString("yyyy-MM-dd");
                    }

                    if (request.ToDate.HasValue)
                    {
                        queryString[QueryString.ToDate] = request.ToDate.Value.Date.ToString("yyyy-MM-dd");
                    }
                }
            );

            public static readonly SverigesRadioApiListEndpointConfiguration<EpisodeSearchRequest, EpisodeListFilterFields, EpisodeListSortFields> SearchEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<EpisodeSearchRequest, EpisodeListFilterFields, EpisodeListSortFields>(
                SearchUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.Query] = request.Query;

                    if (request.ProgramId.HasValue)
                    {
                        queryString[QueryString.ProgramId] = request.ProgramId.Value.ToString("D");
                    }

                    if (request.KanalId.HasValue)
                    {
                        queryString[QueryString.KanalId] = request.KanalId.Value.ToString("D");
                    }
                }
            );

            public static readonly SverigesRadioApiListEndpointConfiguration<EpisodeDetailsMultipleRequest, EpisodeListFilterFields, EpisodeListSortFields> DetailsMultipleUrlEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<EpisodeDetailsMultipleRequest, EpisodeListFilterFields, EpisodeListSortFields>(
                GetMultipleUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.Ids] = string.Join(",", request.Ids.Select(x => x.ToString("D")));
                }
            );

            public static class QueryString
            {
                public const string Query = "query";
                public const string ProgramId = "programid";
                public const string KanalId = "kanalid";

                public const string FromDate = "fromdate";
                public const string ToDate = "todate";

                public const string Ids = "ids";
            }
        }

        public static class Broadcasts
        {
            public const string BaseUrl = "broadcasts";

            public static readonly SverigesRadioApiListEndpointConfiguration<BroadcastListRequest, BroadcastListFilterFields, BroadcastListSortFields> ListEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<BroadcastListRequest, BroadcastListFilterFields, BroadcastListSortFields>(
                BaseUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.ProgramId] = request.ProgramId.ToString("D");
                }
            );

            public static class QueryString
            {
                public const string ProgramId = "programid";
            }
        }

        public static class Podfiles
        {
            public const string BaseUrl = "podfiles";

            public static readonly SverigesRadioApiListEndpointConfiguration<PodfileListRequest, PodfileListFilterFields, PodfileListSortFields> ListEndpointConfiguration = new SverigesRadioApiListEndpointConfiguration<PodfileListRequest, PodfileListFilterFields, PodfileListSortFields>(
                BaseUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.ProgramId] = request.ProgramId.ToString("D");
                }
            );

            public static class QueryString
            {
                public const string ProgramId = "programid";
            }
        }
    }
}
