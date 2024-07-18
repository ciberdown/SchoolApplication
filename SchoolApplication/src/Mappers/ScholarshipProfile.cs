using AutoMapper;
using SchoolApplication.src.Dtos.Scholarship;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Mappers
{
    public class ScholarshipProfile : Profile
    {
        public ScholarshipProfile()
        {
            CreateMap<Scholarship, ScholarshipDto>();

            CreateMap<School, SchoolDto>();
            CreateMap<Student, StudentDto>();

            CreateMap<CreateScholarshipDto, Scholarship>();
        }
    }
}
