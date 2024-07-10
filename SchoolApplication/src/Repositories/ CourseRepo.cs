using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories
{
    public abstract class  CourseRepoBase : ICourseRepo
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