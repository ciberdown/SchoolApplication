using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.StudentRepo
{
    public abstract partial class StudentRepoBase: IStudentRepo
    {
        protected IQueryable<Student> ApplyFilters(IQueryable<Student> res, StudentQueryObject query)
        {
            if (!string.IsNullOrWhiteSpace(query.Name))
                res = res.Where(s => s.Name.Contains(query.Name!));
            if (query.Id.HasValue)
                res = res.Where(s => s.Id == query.Id);
            if (query.SchoolId.HasValue)
                res = res.Where(s => s.School.Id == query.SchoolId);
            if (!string.IsNullOrWhiteSpace(query.Description))
                res = res.Where(s => s.Description != null &&
                            s.Description.Contains(query.Description!
                          ));

            return res;
        }
    }
}
