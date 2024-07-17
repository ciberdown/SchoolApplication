using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Dtos.Student;

namespace SchoolApplication.src.Dtos.School
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<StudentDto>? Students { get; set; }
        public List<CourseDto>? Courses { get; set; }
        public List<NoRelationScholarshipDto>? TakedScholarships { get; set; }
    }
}
