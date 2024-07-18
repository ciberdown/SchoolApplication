using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentAppService _service;
        public StudentController(IStudentAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<StudentResDto>> Get([FromQuery] StudentQueryObject query)
        {
            var students = await _service.Get(query);
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            var student = await _service.GetById(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create([FromBody] CreateStudentInput input)
        {
            var student = await _service.Post(input);
            if(student == null)
            {
                //implement bad req
                return null;
            }
            var created = await GetById(student.Id);
            return created;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.Delete(id);
            return res == true ? NoContent() : BadRequest();
        }


    }
}
