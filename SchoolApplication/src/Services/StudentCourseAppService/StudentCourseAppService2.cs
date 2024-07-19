using SchoolApplication.src.Dtos;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.Services.StudentCourseAppService;

public abstract partial class StudentCourseAppServiceBase : IStudentCourseAppService
{
    protected async Task<int> GetCountAsync(IQueryable<StudentCourse> query)
    {
        return await query.GetCountAsync();
    }

    protected async Task<List<StudentCourse>> GetPagedSCAsync(IQueryable<StudentCourse> query, PaginationQueryObject paginationQueryObject)
    {
        return await query.GetPagedAsync(paginationQueryObject);
    }
}