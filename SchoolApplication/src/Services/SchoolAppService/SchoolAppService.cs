using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Dtos.School;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;
using System.Diagnostics;

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

        public async Task<SchoolDto?> Create(CreateSchoolInput input)
        {
            School newSchool = _mapper.Map<School>(input);


            School? school = await _repo.Create(newSchool);
            if (school == null)
                return null;
            SchoolDto? created = _mapper.Map<SchoolDto>(school);
            return created;

        }

        public async Task<bool> Delete(int id)
        {
            var res = await _repo.Delete(id);
            return res;
        }

        public async Task<SchoolResDto> Get(SchoolQueryObject query)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IQueryable<School> res = _repo.Get(query);

            int count = await GetCountAsync(res);

            //then get filtered items paged list
            var pagedSchools = await GetPagedSchoolAsync(res, query);
            var items = _mapper.Map<List<SchoolDto>>(pagedSchools);

            stopwatch.Stop();
            String excutionDuration = stopwatch.Elapsed.TotalSeconds + " sec";

            var SchoolResDto = new SchoolResDto
            {
                TotalCount = count,
                ExcutionDuration = excutionDuration,
                Items = items
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
