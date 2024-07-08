using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApplication.src.Models
{
    public class Scholarship
    {

        [Required]
        public int AimSchoolId { get; set; }
        public School School { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        public Student Student { get; set; } = null!;
        [Required]
        public int StudentId { get; set; }
    }
}
