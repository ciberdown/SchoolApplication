using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.src.Dtos.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<SCWithoutCourseDto> EnrolledStudents { get; set; } = null!;
        public SchoolWithoutCourseDto EventPlaceSchool { get; set; } = null!;
    }
}