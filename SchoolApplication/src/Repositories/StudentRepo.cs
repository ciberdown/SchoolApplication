using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Dtos.Student;
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
                .Include(s => s.Courses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.School)
                .Include(s => s.Scholarship)
                .ToListAsync();
        }

        public async Task<Student?> GetById(int id)
        {
            return await _context.Students
                .Include(s => s.Courses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.School)
                .Include(s => s.Scholarship)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> Create(Student input)
        {
            var created = await _context.Students.AddAsync(input);
            if (created == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _context.Students.FindAsync(id);
            if(res == null)
                return false;
            
            _context.Students.Remove(res);
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}
