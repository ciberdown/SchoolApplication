using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos.Scholarship;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Controllers
{
    [Route("api/scholarship")]
    [ApiController]
    public class ScholarshipController : ControllerBase
    {
        private readonly IScholarshipAppService _service;

        public ScholarshipController(IScholarshipAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ScholarshipResDto>> Get([FromQuery] ScholarShipQueryObject query)
        {
            var res = await _service.Get(query);
            return Ok(res);
        }

        [HttpGet("${AimSchoolId}/${StudentId}")]
        public async Task<ActionResult<ScholarshipDto>> GetById(int AimSchoolId, int StudentId)
        {
            try
            {
                ScholarshipDto scholarship = await _service.GetById(AimSchoolId, StudentId);
                return Ok(scholarship);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ScholarshipDto>> Create([FromBody] CreateScholarshipDto input)
        {
            Scholarship? res = await _service.Create(input);
            if(res == null)
                return NotFound();
            var created = await GetById(res.AimSchoolId, res.StudentId);
            return created == null ? NotFound() : created;
        }

        [HttpDelete("${AimSchoolId}/${StudentId}")]
        public async Task<IActionResult> Delete(int AimSchoolId, int StudentId)
        {
            var res = await _service.Delete(AimSchoolId, StudentId);
            return res == true ? NoContent() : BadRequest();
        }
    }
}
