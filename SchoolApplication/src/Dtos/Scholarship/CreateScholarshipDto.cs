using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Scholarship
{
    public class CreateScholarshipDto
    {
        [Required]
        public int AimSchoolId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
