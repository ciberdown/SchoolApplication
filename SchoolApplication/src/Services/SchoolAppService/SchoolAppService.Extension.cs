using AutoMapper;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Services.SchoolAppService
{
    public class SchoolAppService : SchoolAppServiceBase, ISchoolAppService
    {
        public SchoolAppService(ISchoolRepo schoolRepo, IMapper mapper) : base(schoolRepo, mapper)
        {
            
        }

    }
}
