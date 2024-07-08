using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Dtos.Student
{
    public class NoRelationScholarshipDto
    {
        public int AimSchoolId { get; set; }
        //public NoRelationSchoolDto School { get; set; } = null!;
        public int Id { get; set; }
        public string SchoolName { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }
    }
}
