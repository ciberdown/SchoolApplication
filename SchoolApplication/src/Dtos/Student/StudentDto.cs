using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<SCWithoutStudentDto>? Courses { get; set; }

        public NoRelationScholarshipDto? Scholarship { get; set; }

        public SchoolWithoutStudentDto School { get; set; } = null!;
    }
}
