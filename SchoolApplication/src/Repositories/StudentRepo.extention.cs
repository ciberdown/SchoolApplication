using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Repositories
{
    public class StudentRepo : StudentRepoBase, IStudentRepo
    {
        public StudentRepo(SchoolDb context) : base(context)
        {
            
        }
    }
}
