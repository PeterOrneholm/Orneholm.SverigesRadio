namespace Orneholm.SverigesRadio.Api.Models
{
    public class ListRequestFields
    {
        public class Programs
        {
            public class Sort
            {

            }

            public class Filter
            {
                public const string Archived = "program.archived";
                public const string HasOnDemand = "program.hasondemand";
                public const string HasPod = "program.haspod";
                public const string ResponsibleEditor = "program.responsibleeditor";
            }
        }
    }
}
