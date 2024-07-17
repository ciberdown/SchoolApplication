using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Helpers.Consts;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.School
{
    public class CreateSchoolInput
    {
        [Required]
        [MaxLength(SchoolConsts.Name.MaxLen)]
        public string Name { get; set; } = null!;

        [MaxLength(SchoolConsts.Description.MaxLen)]
        public string? Description { get; set; }
    }
}
