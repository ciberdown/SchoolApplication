using AutoMapper;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.Services.StudentCourseAppService;

public class StudentCourseAppService : StudentCourseAppServiceBase, IStudentCourseAppService
{
    public StudentCourseAppService(IStudentCourseRepo repo, IMapper mapper) : base(repo, mapper)
    {
        
    }
}