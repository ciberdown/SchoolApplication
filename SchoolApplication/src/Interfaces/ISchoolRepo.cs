using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface ISchoolRepo
    {
        public IQueryable<School> Get(SchoolQueryObject query);
        public Task<School?> GetById(int id);
        public Task<School?> Create(School school);
        public Task<bool> Delete(int id);
    }
}
