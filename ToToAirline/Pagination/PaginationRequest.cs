
namespace ToToAirline.Pagination
{
    public class PaginationRequest
    {
        public string? Sort { get; set; }
        public string? Seach { get; set; }
        public string? SeachBy { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}