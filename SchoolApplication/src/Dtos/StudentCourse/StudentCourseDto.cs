using System.ComponentModel.DataAnnotations;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Dtos.Student;

namespace SchoolApplication.src.Dtos.StudentCourse;

public class StudentCourseDto
{
    public int StudentId { get; set; }
    public StudentDto Student { get; set; } = null!;

    public int CourseId { get; set; }
    public CourseDto Course { get; set; } = null!;

    [Range(0, 20)]
    public int? Grade { get; set; }
}