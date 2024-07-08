using AutoMapper;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentCourse, SCWithoutStudentDto>();
            CreateMap<Scholarship, NoRelationScholarshipDto>();
            CreateMap<School, SchoolWithoutStudentDto>();
            CreateMap<School, NoRelationSchoolDto>();
            CreateMap<Course, CourseWithoutScDto>();
            CreateMap<Course, NoRelationCourseDto>();
        }
    }
}
