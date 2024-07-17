using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Services.SchoolAppService
{
    public abstract partial class SchoolAppServiceBase : ISchoolAppService
    {
        private readonly ISchoolRepo _repo;
        private readonly IMapper _mapper;
        protected SchoolAppServiceBase(ISchoolRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<SchoolResDto> Get(SchoolQueryObject query)
        {
            IQueryable<School> res = _repo.Get(query);

            int count = await GetCountAsync(res);

            //then get filtered items paged list
            var pagedSchools = await GetPagedSchoolAsync(res, query);

            var SchoolResDto = new SchoolResDto
            {
                TotalCount = count,
                Items = _mapper.Map<List<SchoolDto>>(pagedSchools)
            };

            //return standard res
            return SchoolResDto;
        }

        public async Task<SchoolDto?> GetById(int id)
        {
            var res = await _repo.GetById(id);
            if (res == null)
                return null;

            var schoolDto =  _mapper.Map<SchoolDto>(res);
            return schoolDto;
        }
    }
}
