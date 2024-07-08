using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories
{
    public abstract class StudentRepoBase : IStudentRepo
    {
        protected SchoolDb _context {  get; set; }

        public StudentRepoBase(SchoolDb context)
        {
            _context = context;
        }

        public async Task<List<Student>> Get()
        {
            return await _context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.School)
                .Include(s => s.Scholarship)
                .ToListAsync();
        }
    }
}
