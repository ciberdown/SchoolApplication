using AutoMapper;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Services
{
    public class StudentAppService : StudentAppServiceBase, IStudentAppService
    {
        public StudentAppService(IStudentRepo repo, IMapper mapper) : base(repo, mapper)
        {
            
        }
    }
}
