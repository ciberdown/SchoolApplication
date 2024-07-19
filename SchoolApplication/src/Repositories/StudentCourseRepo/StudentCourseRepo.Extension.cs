using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.Repositories.StudentCourseRepo;

public class StudentCourseRepo : StudentCourseRepoBase, IStudentCourseRepo
{
    public StudentCourseRepo(SchoolDb context) : base(context)
    {
        
    }
}