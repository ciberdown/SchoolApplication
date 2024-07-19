using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Dtos.Scholarship;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface IScholarshipAppService
    {
        public Task<ScholarshipResDto> Get(ScholarShipQueryObject query);
        public Task<ScholarshipDto> GetById(int AimSchoolId, int StudentId);
        public Task<Scholarship?> Create(CreateScholarshipDto input);
        public Task<bool> Delete(int AimSchoolId, int StudentId);
    }
}
