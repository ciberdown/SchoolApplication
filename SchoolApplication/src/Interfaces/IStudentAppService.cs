using SchoolApplication.src.Dtos.Student;

namespace SchoolApplication.src.Interfaces
{
    public interface IStudentAppService
    {
        public Task<List<StudentDto>> Get();
    }
}
