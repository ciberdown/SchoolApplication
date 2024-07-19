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
        public async Task<ActionResult<CourseResDto>> Get([FromQuery] CourseQueryObject query)
        {
            var course = await _service.Get(query);
            return Ok(course);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto?>> GetById(int id)
        {
            CourseDto? course = await _service.GetById(id);
            return course == null ? NotFound() : Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.Delete(id);
            if (res == true)
                return NoContent();
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto?>> Create([FromBody] CreateCourseInput input)
        {
            CourseDto? created = await _service.Create(input);
            return created == null ? BadRequest() : Ok(created);
        }

    }
}