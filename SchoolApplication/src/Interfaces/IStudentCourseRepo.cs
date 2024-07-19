using SchoolApplication.src.Dtos.StudentCourse;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces;

public interface IStudentCourseRepo
{
    public IQueryable<StudentCourse> Get(StudentCourseQueryObject query);
    public Task<StudentCourse?> Create(StudentCourse studentCourse);
    public Task<StudentCourse?> GetById(int studentId, int courseId);
    public Task<bool> Delete(int studentId, int courseId);
}