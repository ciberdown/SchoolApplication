using SchoolApplication.src.Helpers.Consts;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Student
{
    public class CreateStudentInput
    {
        [MaxLength(StudentConsts.Name.MaxLen)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(StudentConsts.Description.MaxLen)]
        public string? Description { get; set; }

        [Required]
        public int SchoolId { get; set; }
    }
}
