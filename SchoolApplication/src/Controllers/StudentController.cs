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
        public async Task<List<StudentDto>> Get()
        {
            var students = await _service.Get();
            return students;
        }
    }
}
