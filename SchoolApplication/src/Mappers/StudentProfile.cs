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
            CreateMap<StudentCourse, SCInStudentDto>();
            CreateMap<Scholarship, ScholarshipInStudentDto>();
            CreateMap<School, SchoolInStudentDto>();

        }
    }
}
