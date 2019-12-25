using System.Linq;
using Orneholm.SverigesRadio.Api.Models.Request.Broadcasts;
using Orneholm.SverigesRadio.Api.Models.Request.Channels;
using Orneholm.SverigesRadio.Api.Models.Request.EpisodeGroups;
using Orneholm.SverigesRadio.Api.Models.Request.Episodes;
using Orneholm.SverigesRadio.Api.Models.Request.ExtraBroadcasts;
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

            public static readonly ListEndpointConfiguration<ProgramListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<ProgramListRequest>(
                BaseUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.ChannelId] = request.ChannelId?.ToString("D");
                    queryString[QueryString.ProgramCategoryId] = request.ProgramCategoryId?.ToString("D");
                    queryString[QueryString.IsArchived] = request.IsArchived?.ToString().ToLower();

                    if (request.Filter != null)
                    {
                        queryString[Common.QueryString.FilterField] = request.Filter.GetFilterField();
                        queryString[Common.QueryString.FilterValue] = request.Filter.GetFilterValue();
                    }
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

            public static readonly ListEndpointConfiguration<ProgramCategoryListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<ProgramCategoryListRequest>(
                BaseUrl
            );
        }

        public static class Channels
        {
            public const string BaseUrl = "channels";

            public static readonly ListEndpointConfiguration<ChannelListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<ChannelListRequest>(
                BaseUrl,
                (request, queryString) =>
                {
                    if (!string.IsNullOrEmpty(request.ChannelType))
                    {
                        queryString[Common.QueryString.FilterField] = Filter.ChannelType;
                        queryString[Common.QueryString.FilterValue] = request.ChannelType;
                    }
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
            public const string GetLatestUrl = BaseUrl + "/getlatest";

            public static readonly ListEndpointConfiguration<EpisodeListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<EpisodeListRequest>(
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

            public static readonly ListEndpointConfiguration<EpisodeSearchRequest> SearchEndpointConfiguration = new ListEndpointConfiguration<EpisodeSearchRequest>(
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

            public static readonly ListEndpointConfiguration<EpisodeDetailsMultipleRequest> DetailsMultipleEndpointConfiguration = new ListEndpointConfiguration<EpisodeDetailsMultipleRequest>(
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

        public static class EpisodeGroups
        {
            public const string BaseUrl = "episodes/group";

            public static readonly ListEndpointConfiguration<EpisodeGroupListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<EpisodeGroupListRequest>(
                BaseUrl,
                (request, queryString) =>
                {
                    queryString[QueryString.Id] = request.Id.ToString("D");
                }
            );

            public static class QueryString
            {
                public const string Id = "id";
            }
        }

        public static class Broadcasts
        {
            public const string BaseUrl = "broadcasts";

            public static readonly ListEndpointConfiguration<BroadcastListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<BroadcastListRequest>(
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

        public static class ExtraBroadcasts
        {
            public const string ListExtraUrl = "extra/broadcasts";

            public static readonly ListEndpointConfiguration<ExtraBroadcastListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<ExtraBroadcastListRequest>(
                ListExtraUrl,
                (request, queryString) =>
                {
                    if (request.Date.HasValue)
                    {
                        queryString[QueryString.Date] = request.Date.Value.Date.ToString("yyyy-MM-dd");

                        SverigesRadioUrlHelpers.AddSortQueryStringParams(queryString, fields =>
                        {
                            return fields switch
                            {
                                ExtraBroadcastListSortFields.LocalStartTime => Sort.LocalStartTime,
                                ExtraBroadcastListSortFields.ChannelName => Sort.ChannelName,

                                _ => string.Empty
                            };
                        }, request.Sort);
                    }
                }
            );

            public static class QueryString
            {
                public const string Date = "date";
            }

            public static class Sort
            {
                public const string LocalStartTime = "localstarttime";
                public const string ChannelName = "channelname";
            }
        }

        public static class Podfiles
        {
            public const string BaseUrl = "podfiles";

            public static readonly ListEndpointConfiguration<PodfileListRequest> ListEndpointConfiguration = new ListEndpointConfiguration<PodfileListRequest>(
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

        public static class AudioUrlTemplates
        {
            private const string BaseUrl = "audiourltemplates";
            public const string OnDemandTypesListUrl = BaseUrl + "/ondemandaudiotypes";
            public const string LiveAudioTypesListUrl = BaseUrl + "/liveaudiotypes";
        }

        public static class News
        {
            public const string ProgramNewsListUrl = "news";
            public const string EpisodeNewsListUrl = "news/episodes";
        }
    }
}
