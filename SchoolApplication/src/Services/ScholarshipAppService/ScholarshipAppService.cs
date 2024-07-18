using AutoMapper;
using SchoolApplication.src.Dtos.Scholarship;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;
using System.Diagnostics;

namespace SchoolApplication.src.Services.ScholarshipAppService
{
    public abstract partial class ScholarshipAppServiceBase : IScholarshipAppService
    {
        private readonly IScholarshipRepo _repo;
        private readonly IMapper _mapper;
        protected ScholarshipAppServiceBase(IScholarshipRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ScholarshipResDto> Get(ScholarShipQueryObject query)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IQueryable<Scholarship> res = _repo.Get(query);
            //get all items count before apply pagination
            int count = await GetCountAsync(res);

            //then get filtered items paged list
            var pagedScholarships = await GetPagedScholarshipsAsync(res, query);
            var items = _mapper.Map<List<ScholarshipDto>>(pagedScholarships);

            stopwatch.Stop();
            String excutionDuration = stopwatch.Elapsed.TotalSeconds + " sec";


            var scholarshipResDto = new ScholarshipResDto
            {
                TotalCount = count,
                ExcutionDuration = excutionDuration,
                Items = items
            };

            //return standard res
            return scholarshipResDto;
        }

        public async Task<ScholarshipDto> GetById(int AimSchoolId, int StudentId)
        {
            Scholarship? scholarship = await _repo.GetById(AimSchoolId, StudentId);
            if (scholarship == null)
                throw new Exception("scholarship with this id's not found!");

            ScholarshipDto res = _mapper.Map<ScholarshipDto>(scholarship);
            return res;
        }

        public async Task<Scholarship?> Create(CreateScholarshipDto input)
        {
            Scholarship? scholarship = _mapper.Map<Scholarship>(input);
            return await _repo.Create(scholarship);
        }

        public async Task<bool> Delete(int AimSchoolId, int StudentId)
        {
            return await _repo.Delete(AimSchoolId, StudentId);
        }
    }
}
