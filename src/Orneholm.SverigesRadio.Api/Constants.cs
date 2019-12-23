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

            }
        }

        public static class Programs
        {
            public const string BaseUrl = "programs";

            public static readonly SverigesRadioApiEndpointConfiguration<ProgramListRequest, ProgramFilterFields, ProgramListSortFields> EndpointConfiguration = new SverigesRadioApiEndpointConfiguration<ProgramListRequest, ProgramFilterFields, ProgramListSortFields>(
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
                        ProgramFilterFields.Archived => Filter.Archived,
                        ProgramFilterFields.HasOnDemand => Filter.HasOnDemand,
                        ProgramFilterFields.HasPod => Filter.HasPod,
                        ProgramFilterFields.ResponsibleEditor => Filter.ResponsibleEditor,

                        _ => string.Empty
                    };
                },
                null
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

            public static class Sort
            {

            }
        }
    }
}
