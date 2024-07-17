using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.SchoolRepo
{
    public abstract partial class SchoolRepoBase : ISchoolRepo
    {
        protected IQueryable<School> ApplyFilters(IQueryable<School> res, SchoolQueryObject query)
        {
            if (!string.IsNullOrWhiteSpace(query.Name))
                res = res.Where(s => s.Name.Contains(query.Name!));
            if (query.Id.HasValue)
                res = res.Where(s => s.Id == query.Id);
            if (!string.IsNullOrWhiteSpace(query.Description))
                res = res.Where(s => s.Description != null &&
                            s.Description.Contains(query.Description!
                          ));

            return res;
        }
    }
}
