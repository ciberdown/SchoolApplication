using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<School?> Create(School school)
        {
            School? foundedSchool = await _context.Schools.FirstOrDefaultAsync(sc => sc.Name == school.Name);
            //there is an school with this name
            if (foundedSchool != null)
                throw new Exception("there is an school with this name");
            var res = await _context.Schools.AddAsync(school);
            if(res == null)
                return null;
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _context.Schools.FindAsync(id);
            if (res == null)
                return false;

            _context.Schools.Remove(res);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
