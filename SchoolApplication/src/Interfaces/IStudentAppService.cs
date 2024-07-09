using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface IStudentAppService
    {
        public Task<StudentResDto> Get();
        public Task<StudentDto?> GetById(int id);
        public Task<StudentDto?> Post(CreateStudentInput input);
        public Task<bool> Delete(int id);
    }
}
