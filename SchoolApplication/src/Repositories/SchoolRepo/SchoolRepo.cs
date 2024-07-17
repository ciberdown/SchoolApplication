using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.SchoolRepo
{
    public abstract partial class SchoolRepoBase : ISchoolRepo
    {
        private SchoolDb _context { get; set; }
        protected SchoolRepoBase(SchoolDb context)
        {
            _context = context;
        }
        public IQueryable<School> Get(SchoolQueryObject paginationObjectQuery)
        {
            IQueryable<School> res = _context.Schools
                .Include(s => s.Students)
                .ThenInclude(st => st.Courses)
                .Include(s => s.Courses)
                .ThenInclude(c => c.EnrolledStudents)
                .Include(s => s.TakedScholarships)
                .AsQueryable();

            //apply filters
            res = ApplyFilters(res, paginationObjectQuery);

            return res;
        }

        public async Task<School?> GetById(int id)
        {
            return await _context.Schools
                .Include(s => s.Students)
                .Include(s => s.Courses)
                .Include(s => s.TakedScholarships)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
