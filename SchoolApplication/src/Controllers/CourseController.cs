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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.Delete(id);
            if (res == true)
                return NoContent();
            return BadRequest();
        }

        [HttpPost]
        public async Task<CourseDto> Create([FromBody] CreateCourseInput input)
        {
            CourseDto? created = await _service.Create(input);
            if (created == null)
                return null;
            return created;
        }

    }
}