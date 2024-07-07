using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        [Range(0, 20)]
        public int? Grade { get; set; }

    }
}
