

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
        public async Task<SchoolResDto> Get([FromQuery] SchoolQueryObject query)
        {
            var res = await _service.Get(query);
            return res;
        }

        [HttpGet("{id}")]
        public async Task<SchoolDto> GetById(int id)
        {
            var school = await _service.GetById(id);
            if (school == null)
            {
                //implement not found
                return null;
            }
            return school;
        }


    }
}
