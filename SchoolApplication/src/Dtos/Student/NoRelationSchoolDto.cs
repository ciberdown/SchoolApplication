namespace SchoolApplication.src.Dtos.Student
{
    public class NoRelationSchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<NoRelationCourseDto>? Courses { get; set; }
        public List<NoRelationScholarshipDto>? TakedScholarships { get; set; }
    }
}
