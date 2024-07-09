using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos;
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
        public async Task<StudentResDto> Get()
        {
            var students = await _service.Get();
            return students;
        }

        [HttpGet("{id}")]
        public async Task<StudentDto> GetById(int id)
        {
            var student = await _service.GetById(id);
            if(student == null)
            {
                //implement not found
                return null;
            }
            return student;
        }

        [HttpPost]
        public async Task<StudentDto> Create([FromBody] CreateStudentInput input)
        {
            var student = await _service.Post(input);
            if(student == null)
            {
                //implement bad req
                return null;
            }
            return await GetById(student.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.Delete(id);
            if(res == true)
                return NoContent();
            return BadRequest();
        }
    }
}
