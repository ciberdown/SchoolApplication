using SchoolApplication.src.Helpers.Consts;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.src.Dtos.School
{
    public class SchoolQueryObject : PaginationQueryObject
    {
        public int? Id { get; set; }

        [MaxLength(SchoolConsts.Name.MaxLen)]
        public string? Name { get; set; }

        [MaxLength(SchoolConsts.Description.MaxLen)]
        public string? Description { get; set; }
    }
}
