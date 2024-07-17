using SchoolApplication.src.Dtos;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Services.StudentAppService
{
    public abstract partial class StudentAppServiceBase: IStudentAppService
    {
        protected async Task<int> GetCountAsync(IQueryable<Student> query)
        {
            return await query.GetCountAsync();
        }

        protected async Task<List<Student>> GetPagedStudentsAsync(IQueryable<Student> query, PaginationQueryObject paginationQueryObject)
        {
            return await query.GetPagedAsync(paginationQueryObject);
        }
    }
}
