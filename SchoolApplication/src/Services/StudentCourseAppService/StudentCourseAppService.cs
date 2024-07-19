using System.Diagnostics;
using AutoMapper;
using SchoolApplication.src.Dtos.StudentCourse;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.Services.StudentCourseAppService;

public abstract partial class StudentCourseAppServiceBase : IStudentCourseAppService
{
    protected readonly IStudentCourseRepo _repo;
    protected readonly IMapper _mapper;
    protected StudentCourseAppServiceBase(IStudentCourseRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<StudentCourseResDto> Get(StudentCourseQueryObject query)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        IQueryable<StudentCourse> res = _repo.Get(query);
        //get all items count before apply pagination
        int count = await GetCountAsync(res);

        //then get filtered items paged list
        var pagedRes = await GetPagedSCAsync(res, query);
        var items = _mapper.Map<List<StudentCourseDto>>(pagedRes);

        stopwatch.Stop();
        String excutionDuration = stopwatch.Elapsed.TotalSeconds + " sec";


        var studentResDto = new StudentCourseResDto
        {
            TotalCount = count,
            ExcutionDuration = excutionDuration,
            Items = items
        };

        //return standard res
        return studentResDto;
    }

    public async Task<StudentCourseDto?> GetById(int studentId, int courseId)
    {
        var res = await _repo.GetById(studentId, courseId);
        
        return res == null ? null : _mapper.Map<StudentCourseDto>(res);
    }

    public async Task<bool> Delete(int studentId, int courseId)
    {
        var res = await _repo.Delete(studentId, courseId);
        return res;
    }

    public async Task<StudentCourse?> Create(CreateStudentCourseInput input)
    {
        StudentCourse sc = _mapper.Map<StudentCourse>(input);
        var res = await _repo.Create(sc);
        return res;
    }
}