using AutoMapper;
using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;
using Sprache;

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
            CreateMap<CreateStudentInput, Student>();
            CreateMap<Student, NoRelationStudentDto>();
            

            CreateMap<List<Student>, StudentResDto>()
                .ForMember("TotalCount", opt => opt.MapFrom(src => src.Count))
                .ForMember("Items", opt => opt.MapFrom(src => src));
        }
    }
}
