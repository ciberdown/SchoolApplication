using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Repositories.CourseRepo
{
    public class CourseRepo : CourseRepoBase, ICourseRepo
    {
        public CourseRepo(SchoolDb context) : base(context)
        {

        }
    }
}