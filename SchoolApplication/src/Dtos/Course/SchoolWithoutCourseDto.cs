using SchoolApplication.src.Dtos.Student;

namespace SchoolApplication.src.Dtos.Course
{
    public class SchoolWithoutCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<NoRelationStudentDto>? Students { get; set; }
        public List<NoRelationCourseDto>? Courses { get; set; }
        public List<NoRelationScholarshipDto>? TakedScholarships { get; set; }
    }
}