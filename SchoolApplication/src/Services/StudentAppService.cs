using AutoMapper;
using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

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

        public async Task<StudentResDto> Get()
        {
            var students = await _repo.Get();
            //var res = _mapper.Map<List<StudentDto>>(students);
            var sdrRes = _mapper.Map<StudentResDto>(students);
            return sdrRes;
        }

        public async Task<StudentDto?> GetById(int id)
        {
            var student = await _repo.GetById(id);
            if (student == null)
            {
                return null;
            }
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }

        public async Task<StudentDto?> Post(CreateStudentInput input)
        {
            var newStudent = _mapper.Map<Student>(input);
            var student = await _repo.Create(newStudent);
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }
    }
}
