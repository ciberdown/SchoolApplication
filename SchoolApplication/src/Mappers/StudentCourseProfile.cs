using AutoMapper;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Dtos.StudentCourse;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Mappers;

public class StudentCourseProfile : Profile
{
    public StudentCourseProfile()
    {
        CreateMap<StudentCourse, StudentCourseDto>();
        
        CreateMap<Student, StudentDto>();
        CreateMap<Course, CourseDto>();
        
        CreateMap<CreateStudentCourseInput, StudentCourse>();

    }
}