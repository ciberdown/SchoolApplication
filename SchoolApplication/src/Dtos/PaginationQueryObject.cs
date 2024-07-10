using Microsoft.EntityFrameworkCore;

namespace SchoolApplication.src.Dtos
{
    interface IPagedResult<T>
    {
        int TotalCount { get; set; }
        IQueryable<T> Items { get; set; }
    }

    public abstract class PaginationQueryObject
    {
        public int? MaxResultCount { get; set; }
        public int? SkipCount { get; set; }

        protected PaginationQueryObject()
        {
            MaxResultCount = 10;
            SkipCount = 0;
        }
    }

    public static class GetCount
    {
        public static async Task<int> GetCountAsync<T>(this IQueryable<T> allItemsQuery)
        {
            return await allItemsQuery.CountAsync();
        }
    }

    public static class GetPaged
    {
        public static async Task<List<T>> GetPagedAsync<T>(this IQueryable<T> filteredQeury, PaginationQueryObject paginationQueryObject)
        {
            filteredQeury = filteredQeury.Skip(paginationQueryObject.SkipCount!.Value).Take(paginationQueryObject.MaxResultCount!.Value);
            return await filteredQeury.ToListAsync();
        }
    }

}
