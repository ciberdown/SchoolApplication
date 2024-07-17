using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Repositories.SchoolRepo
{
    public class SchoolRepo : SchoolRepoBase, ISchoolRepo
    {
        public SchoolRepo(SchoolDb context): base(context)
        {
            
        }
    }
}
