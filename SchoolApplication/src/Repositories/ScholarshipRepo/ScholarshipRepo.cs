using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Dtos.Scholarship;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.ScholarshipRepo
{
    public abstract partial class ScholarshipRepoBase : IScholarshipRepo
    {
        private readonly SchoolDb _context;

        protected ScholarshipRepoBase(SchoolDb context)
        {
            _context = context;
        }


        public IQueryable<Scholarship> Get(ScholarShipQueryObject paginationObjectQuery)
        {
            IQueryable<Scholarship> res = _context.Scholarships
                .Include(sc => sc.School)
                    .ThenInclude(s => s.Students)
                .Include(sc => sc.School)
                    .ThenInclude(s => s.Courses)
                .Include(sc => sc.Student)
                    .ThenInclude(s => s.School)
                .Include(sc => sc.Student)
                    .ThenInclude(s => s.Courses);



            //apply filters
            res = ApplyFilters(res, paginationObjectQuery);
            
            return res;
        }

        public async Task<Scholarship?> GetById(int AimSchoolId, int StudentId)
        {
            Scholarship? res = await _context.Scholarships
                .Include(sc => sc.School)
                    .ThenInclude(s => s.Students)
                .Include(sc => sc.School)
                    .ThenInclude(s => s.Courses)
                .Include(sc => sc.Student)
                    .ThenInclude(s => s.School)
                .Include(sc => sc.Student)
                    .ThenInclude(s => s.Courses)
                .FirstOrDefaultAsync(ss => ss.StudentId == StudentId && ss.AimSchoolId == AimSchoolId);

            return res;
        }


        public async Task<Scholarship?> Create(Scholarship scholarship)
        {
            var res = await _context.Scholarships
                .AddAsync(scholarship);

            if(res == null)
                return null;

            await _context.SaveChangesAsync();
            
            return scholarship;
        }

        public async Task<bool> Delete(int AimSchoolId, int StudentId)
        {
            var founded = await _context.Scholarships
                .FirstOrDefaultAsync(ss => ss.StudentId == StudentId && ss.AimSchoolId == AimSchoolId);

            if(founded == null)
                return false;

            _context.Scholarships.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
