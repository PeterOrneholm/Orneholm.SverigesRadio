namespace Orneholm.SverigesRadio.Api.Models
{
    public class ListRequestPagination
    {
        private ListRequestPagination(bool paginationEnabled, int? pageNumber, int? pageSize)
        {
            PaginationEnabled = paginationEnabled;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public bool PaginationEnabled { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public static ListRequestPagination Disabled()
        {
            return new ListRequestPagination(false, null, null);
        }

        public static ListRequestPagination TakeTen()
        {
            return new ListRequestPagination(true, 1, 10);
        }

        public static ListRequestPagination For(int pageNumber, int pageSize)
        {
            return new ListRequestPagination(true, pageNumber, pageSize);
        }
    }
}
