using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SchoolApplication.src.Dtos.Student;

namespace SchoolApplication.src.Dtos.Course
{
    public class SCWithoutCourseDto
    {
        public int StudentId { get; set; }
        public NoRelationStudentDto Student { get; set; } = null!;

        public int CourseId { get; set; }

        [Range(0, 20)]
        public int? Grade { get; set; }
    }
}