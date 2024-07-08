using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Student
{
    public class CourseWithoutScDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public NoRelationSchoolDto EventPlaceSchool { get; set; } = null!;
    }
}
