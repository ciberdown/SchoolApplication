using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApplication.src.Models
{
    public class Scholarship
    {
        public int Id { get; set; }
        public string SchoolName { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }
        public Student Student { get; set; } = null!;
        [Required]
        public int StudentId { get; set; }
    }
}
