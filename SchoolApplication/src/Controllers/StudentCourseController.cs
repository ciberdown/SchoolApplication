using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos.StudentCourse;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Controllers;

[Route("app/studentCourse")]
[ApiController]
public class StudentCourseController : ControllerBase
{
    private readonly IStudentCourseAppService _service;
    
    public StudentCourseController(IStudentCourseAppService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<StudentCourseResDto>> Get([FromQuery] StudentCourseQueryObject query)
    {
        var res = await _service.Get(query);
        return res;
    }

    [HttpGet("{studentId}/{courseId}")]
    public async Task<ActionResult<StudentCourseDto>> GetById(int studentId, int courseId)
    {
        try
        {
            var res = await _service.GetById(studentId, courseId);
            if (res == null)
                return BadRequest();
            return res;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{studentId}/{courseId}")]
    public async Task<IActionResult> Delete(int studentId, int courseId)
    {
        bool removed = await _service.Delete(studentId, courseId);
        return removed == true ? NoContent() : NotFound();
    }


    [HttpPost]
    public async Task<ActionResult<StudentCourseDto>> Create([FromBody] CreateStudentCourseInput input)
    {
        try
        {
            StudentCourse? res = await _service.Create(input);
            if (res == null)
                return BadRequest();
            return await GetById(res.StudentId, res.CourseId);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}