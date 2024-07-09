using SchoolApplication.src.Helpers.Consts;
using SchoolApplication.src.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.Student
{
    public class StudentQueryObject
    {
        public int? Id { get; set; }
        [MaxLength(StudentConsts.Name.MaxLen)]
        public string? Name { get; set; } = null!;

        [MaxLength(StudentConsts.Description.MaxLen)]
        public string? Description { get; set; }

        public int? SchoolId { get; set; }
    }
}
