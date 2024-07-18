using SchoolApplication.src.Dtos;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Services.ScholarshipAppService
{
    public abstract partial class ScholarshipAppServiceBase : IScholarshipAppService
    {
        protected async Task<int> GetCountAsync(IQueryable<Scholarship> query)
        {
            return await query.GetCountAsync();
        }

        protected async Task<List<Scholarship>> GetPagedScholarshipsAsync(IQueryable<Scholarship> query, PaginationQueryObject paginationQueryObject)
        {
            return await query.GetPagedAsync(paginationQueryObject);
        }
    }
}
