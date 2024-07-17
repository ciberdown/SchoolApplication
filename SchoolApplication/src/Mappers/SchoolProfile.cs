using AutoMapper;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Mappers
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, SchoolDto>();

            CreateMap<Student, StudentDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<Scholarship, NoRelationScholarshipDto>();

            CreateMap<CreateSchoolInput, School>();
        }
    }
}
