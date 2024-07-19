using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Repositories.ScholarshipRepo
{
    public class ScholarshipRepo : ScholarshipRepoBase, IScholarshipRepo
    {
        public ScholarshipRepo(SchoolDb context) : base(context)
        {
            
        }
    }
}
