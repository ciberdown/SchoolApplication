using SchoolApplication.src.Dtos.Scholarship;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface IScholarshipRepo
    {
        public IQueryable<Scholarship> Get(ScholarShipQueryObject paginationObjectQuery);
        public Task<Scholarship?> GetById(int AimSchoolId, int StudentId);
        public Task<Scholarship?> Create(Scholarship scholarship);
        public Task<bool> Delete(int AimSchoolId, int StudentId);

    }
}
