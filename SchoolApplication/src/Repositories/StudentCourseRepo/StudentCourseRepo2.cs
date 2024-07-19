using SchoolApplication.src.Dtos.StudentCourse;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.Repositories.StudentCourseRepo;

public abstract partial class StudentCourseRepoBase : IStudentCourseRepo
{
    protected IQueryable<StudentCourse> ApplyFilters(IQueryable<StudentCourse> res, StudentCourseQueryObject query)
    {
        if (query.StudentId.HasValue)
            res = res.Where(s => s.StudentId == query.StudentId);
        if (query.CourseId.HasValue)
            res = res.Where(s => s.CourseId == query.CourseId);
        if (query.Grade.HasValue)
            res = res.Where(s => s.Grade == query.Grade);

        return res;
    }
}