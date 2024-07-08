using AutoMapper;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Services
{
    public abstract class StudentAppServiceBase : IStudentAppService
    {
        private IStudentRepo _repo;
        private IMapper _mapper;
        protected StudentAppServiceBase(IStudentRepo repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> Get()
        {
            var students = await _repo.Get();
            var res = _mapper.Map<List<StudentDto>>(students);
            return res;
        }
    }
}
