using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Dtos.Student;

namespace SchoolApplication.src.Dtos.Scholarship
{
    public class ScholarshipDto
    {
        [Required]
        public int AimSchoolId { get; set; }
        public SchoolDto School { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        public StudentDto Student { get; set; } = null!;
        [Required]
        public int StudentId { get; set; }
    }
}
