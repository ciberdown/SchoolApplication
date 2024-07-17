using SchoolApplication.src.Helpers.Consts;
using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Course
{
    public class CreateCourseInput
    {
        [Required]
        [MaxLength(CourseConsts.Name.MaxLen)]
        public string Name { get; set; } = null!;

        [MaxLength(CourseConsts.Description.MaxLen)]
        public string? Description { get; set; }

        [Required]
        public int SchoolId { get; set; }
    }
}
