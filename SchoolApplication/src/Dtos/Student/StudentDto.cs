using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<SCInStudentDto>? StudentCourses { get; set; }

        public ScholarshipInStudentDto? Scholarship { get; set; }

        [Required]
        public int SchoolId { get; set; }
        public SchoolInStudentDto School { get; set; }
    }
}
