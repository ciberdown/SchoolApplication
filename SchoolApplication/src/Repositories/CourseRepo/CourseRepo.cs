using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.CourseRepo
{
    public abstract partial class CourseRepoBase: ICourseRepo
    {
        protected IQueryable<Course> ApplyFilters(IQueryable<Course> res, CourseQueryObject query)
        {
            if (!string.IsNullOrWhiteSpace(query.Name))
                res = res.Where(c => c.Name.Contains(query.Name!));
            if (query.Id.HasValue)
                res = res.Where(c => c.Id == query.Id);
            if (query.SchoolId.HasValue)
                res = res.Where(c => c.SchoolId == query.SchoolId);
            if (!string.IsNullOrWhiteSpace(query.Description))
                res = res.Where(c => c.Description != null &&
                    c.Description.Contains(query.Description!
                ));

            return res;
        }
    }
}
