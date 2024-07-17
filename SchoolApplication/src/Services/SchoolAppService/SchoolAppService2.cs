using SchoolApplication.src.Dtos;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Services.SchoolAppService
{
    public abstract partial class SchoolAppServiceBase : ISchoolAppService
    {
        protected async Task<int> GetCountAsync(IQueryable<School> query)
        {
            return await query.GetCountAsync();
        }

        protected async Task<List<School>> GetPagedSchoolAsync(IQueryable<School> query, PaginationQueryObject paginationQueryObject)
        {
            return await query.GetPagedAsync(paginationQueryObject);
        }
    }
}
