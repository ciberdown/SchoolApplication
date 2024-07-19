using SchoolApplication.src.Dtos.StudentCourse;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces;

public interface IStudentCourseAppService
{
    public Task<StudentCourseResDto> Get(StudentCourseQueryObject query);
    public Task<StudentCourseDto?> GetById(int studentId, int courseId);
    public Task<bool> Delete(int studentId, int courseId);
    public Task<StudentCourse?> Create(CreateStudentCourseInput input);
}