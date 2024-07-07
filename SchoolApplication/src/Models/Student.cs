using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        
        public List<StudentCourse>? StudentCourses { get; set; }
        
        public Scholarship? Scholarship { get; set; }

        [Required]
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
