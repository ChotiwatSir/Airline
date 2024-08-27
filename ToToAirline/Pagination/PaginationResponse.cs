
namespace ToToAirline.Pagination
{
    public class PaginationResponse<TEntity>
    {
        public PaginationResponse(int count, TEntity data, int page, int pageSize)
        {
            Count = count;
            Data = data;
            Page = page;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling((Double)Count/PageSize);
        }

        public int Count { get; set; }
        public TEntity Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
    }
}