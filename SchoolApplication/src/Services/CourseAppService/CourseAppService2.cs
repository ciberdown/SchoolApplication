using SchoolApplication.src.Dtos;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Services.CourseAppService
{
    public abstract partial class CourseAppServiceBase: ICourseAppService
    {
        protected async Task<int> GetCountAsync(IQueryable<Course> query)
        {
            return await query.GetCountAsync();
        }

        protected async Task<List<Course>> GetPagedStudentsAsync(IQueryable<Course> query, PaginationQueryObject paginationQueryObject)
        {
            return await query.GetPagedAsync(paginationQueryObject);
        }
    }
}
