using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface ISchoolRepo
    {
        public IQueryable<School> Get(SchoolQueryObject query);
        public Task<School?> GetById(int id);

    }
}
