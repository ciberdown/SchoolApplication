

using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Controllers
{
    [Route("api/school")]
    [ApiController]
    public class SchoolController(ISchoolAppService service) : ControllerBase
    {
        private readonly ISchoolAppService _service = service;

        [HttpGet]
        public async Task<ActionResult<SchoolResDto>> Get([FromQuery] SchoolQueryObject query)
        {
            var res = await _service.Get(query);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDto>> GetById(int id)
        {
            var school = await _service.GetById(id);
            if (school == null)
            {
                //implement not found
                return NotFound();
            }
            return Ok(school);
        }

        [HttpPost]
        public async Task<ActionResult<SchoolDto>> Create([FromBody] CreateSchoolInput input)
        {
            try
            {
                SchoolDto? createdSchool = await _service.Create(input);
                if (createdSchool == null)
                    return BadRequest();
                return Ok(createdSchool);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _service.Delete(id);
            if (res == false)
                return NotFound();
            return NoContent();
        }
    }
}
