using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseAppService _service;

        public CourseController(ICourseAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<CourseResDto> Get([FromQuery] CourseQueryObject query)
        {
            var course = await _service.Get(query);
            return course;
        }

        [HttpGet("{id}")]
        public async Task<CourseDto> GetById(int id)
        {
            var course = await _service.GetById(id);
            if(course == null)
            {
                //implement not found
                return null;
            }
            return course;
        }

    }
}