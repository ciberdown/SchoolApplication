namespace SchoolApplication.src.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<Student>? Students { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Scholarship>? TakedScholarships { get; set; }
    }
}
