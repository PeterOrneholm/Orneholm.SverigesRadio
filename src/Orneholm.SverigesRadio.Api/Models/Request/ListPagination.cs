namespace Orneholm.SverigesRadio.Api.Models.Request
{
    public class ListPagination
    {
        private ListPagination(bool paginationEnabled, int? pageNumber, int? pageSize)
        {
            PaginationEnabled = paginationEnabled;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public bool PaginationEnabled { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public static ListPagination Disabled()
        {
            return new ListPagination(false, null, null);
        }

        public static ListPagination FirstPage()
        {
            return new ListPagination(true, 1, SverigesRadioApiDefaults.PageSize);
        }

        public static ListPagination TakeFirst(int pageSize)
        {
            return new ListPagination(true, 1, pageSize);
        }

        public static ListPagination WithPageAndSize(int pageNumber, int pageSize)
        {
            return new ListPagination(true, pageNumber, pageSize);
        }
    }
}
