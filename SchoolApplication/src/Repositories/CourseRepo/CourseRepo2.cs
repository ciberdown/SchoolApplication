using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.CourseRepo
{
    public abstract partial class  CourseRepoBase : ICourseRepo
    {
        public SchoolDb _context { get; set; }

        protected CourseRepoBase(SchoolDb context)
        {
            _context = context;
        }

        public IQueryable<Course> Get(CourseQueryObject paginationObjectQuery)
        {
            IQueryable<Course> res =  _context.Courses
                .Include(c => c.EnrolledStudents)
                .ThenInclude(sc => sc.Student)
                .Include(c => c.EventPlaceSchool)
                .ThenInclude(s => s.Courses)
                .AsQueryable();

            res = ApplyFilters(res, paginationObjectQuery);
            
            return res;
        }

        public async Task<Course?> GetById(int id)
        {
            return await _context.Courses
                .Include(c => c.EnrolledStudents)
                .Include(c => c.EventPlaceSchool)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _context.Courses.FindAsync(id);
            if(res == null)
                return false;
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return true;

        }


        public async Task<Course?> Create(Course course)
        {
            var res = await _context.Courses.AddAsync(course);
            if(res == null)
                return null;

            await _context.SaveChangesAsync();
            return course;
        }






    }
}