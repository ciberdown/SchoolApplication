using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.School
{
    public class StudentWithoutSchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<Models.StudentCourse>? Courses { get; set; }

        public NoRelationScholarshipDto? Scholarship { get; set; }
    }
}
