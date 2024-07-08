using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Student
{
    public class SCWithoutStudentDto
    {
        public int CourseId { get; set; }
        public CourseWithoutScDto Course { get; set; } = null!;

        [Range(0, 20)]
        public int? Grade { get; set; }
    }
}
