using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Dtos.Student;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Scholarship
{
    public class ScholarShipQueryObject : PaginationQueryObject
    {
        public int? AimSchoolId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Salary { get; set; }
        public int? StudentId { get; set; }
    }
}
