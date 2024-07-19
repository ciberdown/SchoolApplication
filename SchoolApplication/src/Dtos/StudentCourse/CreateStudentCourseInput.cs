using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.StudentCourse;

public class CreateStudentCourseInput
{
    [Required]
    public int StudentId { get; set; }

    [Required]
    public int CourseId { get; set; }

    [Range(0, 20)] 
    public int? Grade { get; set; } = null;
}