using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<StudentCourse> StudentCourses { get; set; } = null!;

        [Required]
        public int SchoolId { get; set; }
        public School School { get; set; } = null!;
    }
}
