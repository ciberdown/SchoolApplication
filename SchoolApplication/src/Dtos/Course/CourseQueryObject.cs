using System.ComponentModel.DataAnnotations;
using SchoolApplication.src.Helpers.Consts;

namespace SchoolApplication.src.Dtos.Course
{
    public class CourseQueryObject : PaginationQueryObject
    {
        public int? Id { get; set; }
        [MaxLength(CourseConsts.Name.MaxLen)]
        public string? Name { get; set; } = null!;

        [MaxLength(CourseConsts.Description.MaxLen)]
        public string? Description { get; set; }

        public int? SchoolId { get; set; }
    }
}