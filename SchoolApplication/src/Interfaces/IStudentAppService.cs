using SchoolApplication.src.Dtos.Student;

namespace SchoolApplication.src.Interfaces
{
    public interface IStudentAppService
    {
        public Task<StudentResDto> Get(StudentQueryObject query);
        public Task<StudentDto?> GetById(int id);
        public Task<StudentDto?> Post(CreateStudentInput input);
        public Task<bool> Delete(int id);
    }
}
