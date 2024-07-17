using AutoMapper;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Services.StudentAppService
{
    public class StudentAppService : StudentAppServiceBase, IStudentAppService
    {
        public StudentAppService(IStudentRepo repo, IMapper mapper) : base(repo, mapper)
        {

        }
    }
}
