using AutoMapper;
using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;
using System.Diagnostics;

namespace SchoolApplication.src.Services.StudentAppService
{
    public abstract partial class StudentAppServiceBase : IStudentAppService
    {
        private IStudentRepo _repo;
        private IMapper _mapper;
        protected StudentAppServiceBase(IStudentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _repo.Delete(id);
            return res;
        }

        public async Task<StudentResDto> Get(StudentQueryObject query)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IQueryable<Student> res = _repo.Get(query);
            //get all items count before apply pagination
            int count = await GetCountAsync(res);

            //then get filtered items paged list
            var pagedStudents = await GetPagedStudentsAsync(res, query);
            var items = _mapper.Map<List<StudentDto>>(pagedStudents);

            stopwatch.Stop();
            String excutionDuration = stopwatch.Elapsed.TotalSeconds + " sec";


            var studentResDto = new StudentResDto
            {
                TotalCount = count,
                ExcutionDuration = excutionDuration,
                Items = items
            };

            //return standard res
            return studentResDto;
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
