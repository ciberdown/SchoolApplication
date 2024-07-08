using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Student
{
    public class NoRelationCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
