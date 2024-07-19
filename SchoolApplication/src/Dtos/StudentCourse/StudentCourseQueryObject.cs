using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.StudentCourse;

public class StudentCourseQueryObject : PaginationQueryObject
{
    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    [Range(0, 20)]
    public int? Grade { get; set; }
}