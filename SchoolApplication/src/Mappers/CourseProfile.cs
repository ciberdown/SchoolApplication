using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Mappers
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();

            CreateMap<StudentCourse, SCWithoutCourseDto>();
            CreateMap<School, SchoolWithoutCourseDto>();
            CreateMap<Student, NoRelationStudentDto>();
            CreateMap<Course, NoRelationCourseDto>();
            CreateMap<Scholarship, NoRelationScholarshipDto>();
            CreateMap<CreateCourseInput, Course>();
            
        }
    }
}