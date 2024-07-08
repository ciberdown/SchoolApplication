using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Dtos.Student
{
    public class SchoolWithoutStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<NoRelationCourseDto>? Courses { get; set; }
        public List<NoRelationScholarshipDto>? TakedScholarships { get; set; }
        public List<NoRelationStudentDto>? Students { get; set; }

    }
}
