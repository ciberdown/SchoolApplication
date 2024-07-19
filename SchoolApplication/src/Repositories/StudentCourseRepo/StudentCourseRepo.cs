using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Dtos.StudentCourse;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.Repositories.StudentCourseRepo;

public abstract partial class StudentCourseRepoBase : IStudentCourseRepo
{
    protected readonly SchoolDb _context;
    protected StudentCourseRepoBase(SchoolDb context)
    {
        _context = context;
    }
    public IQueryable<StudentCourse> Get(StudentCourseQueryObject paginationObjectQuery)
    {
        IQueryable<StudentCourse> res = _context.StudentCourses
            .Include(s => s.Student)
            .ThenInclude(sc => sc.Courses)
            .Include(s => s.Student)
            .ThenInclude(sc => sc.Scholarship)
            .Include(s => s.Student)
            .ThenInclude(sc => sc.School)
            
            .Include(s => s.Course)
            .ThenInclude(c => c.EnrolledStudents)
            .Include(s => s.Course)
            .ThenInclude(c => c.EventPlaceSchool)
            .AsQueryable();
       
        //apply filters
        res = ApplyFilters(res, paginationObjectQuery);

        return res;
    }

    public async Task<StudentCourse?> Create(StudentCourse studentCourse)
    {
        if (await _context.Students.FindAsync(studentCourse.StudentId) == null)
            throw new Exception($"student with id {studentCourse.StudentId} not found!");
        
        if (await _context.Courses.FindAsync(studentCourse.CourseId) == null)
            throw new Exception($"course with id {studentCourse.CourseId} not found!");

        var res = await _context.StudentCourses.AddAsync(studentCourse);
        if (res == null)
            throw new Exception("item does not create!");
        await _context.SaveChangesAsync();
        return studentCourse;
    }

    public async Task<StudentCourse?> GetById(int studentId, int courseId)
    {
        var founded = await _context.StudentCourses
            .Include(s => s.Student)
            .ThenInclude(sc => sc.Courses)
            .Include(s => s.Student)
            .ThenInclude(sc => sc.Scholarship)
            .Include(s => s.Student)
            .ThenInclude(sc => sc.School)
            
            .Include(s => s.Course)
            .ThenInclude(c => c.EnrolledStudents)
            .Include(s => s.Course)
            .ThenInclude(c => c.EventPlaceSchool)
            .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

        if (founded == null)
            throw new Exception("studentCourse with these id's not found!");
        return founded;
    }

    public async Task<bool> Delete(int studentId, int courseId)
    {
        var founded = await _context.StudentCourses
            .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

        if (founded == null)
            return false;

        _context.StudentCourses.Remove(founded);
        await _context.SaveChangesAsync();
        return true;
    }
}