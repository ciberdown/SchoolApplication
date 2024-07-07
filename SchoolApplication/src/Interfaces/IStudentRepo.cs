using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface IStudentRepo
    {
        public Task<List<Student>> Get();
    }
}
