using SchoolApplication.src.Dtos.Scholarship;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.ScholarshipRepo
{
    public abstract partial class ScholarshipRepoBase : IScholarshipRepo
    {
        protected IQueryable<Scholarship> ApplyFilters(IQueryable<Scholarship> res, ScholarShipQueryObject query)
        {
            if (query.AimSchoolId.HasValue)
                res = res.Where(s => s.AimSchoolId == query.AimSchoolId);
            if (query.StudentId.HasValue)
                res = res.Where(s => s.StudentId == query.StudentId);
            if (query.Salary.HasValue)
                res = res.Where(s => s.Salary == query.Salary);

            return res;
        }
    }
}
