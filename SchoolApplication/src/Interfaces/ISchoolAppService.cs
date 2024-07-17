using SchoolApplication.src.Dtos.School;

namespace SchoolApplication.src.Interfaces
{
    public interface ISchoolAppService
    {
        public Task<SchoolResDto> Get(SchoolQueryObject query);

        public Task<SchoolDto?> GetById(int id);
    }
}
