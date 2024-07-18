using AutoMapper;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Services.ScholarshipAppService
{
    public class ScholarshipAppService : ScholarshipAppServiceBase, IScholarshipAppService
    {
        public ScholarshipAppService(IScholarshipRepo repo, IMapper mapper) : base(repo, mapper)
        {
            
        }
    }
}
