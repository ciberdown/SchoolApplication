using AutoMapper;
using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Repositories.StudentRepo
{
    public class StudentRepo : StudentRepoBase, IStudentRepo
    {
        public StudentRepo(SchoolDb context) : base(context)
        {
        }
    }
}
