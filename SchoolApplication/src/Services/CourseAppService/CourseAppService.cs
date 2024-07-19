using AutoMapper;
using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;
using System.Diagnostics;

namespace SchoolApplication.src.Services.CourseAppService
{
    public abstract partial class CourseAppServiceBase : ICourseAppService
    {
        public ICourseRepo _repo { get; set; }
        public IMapper _mapper { get; set; }
        protected CourseAppServiceBase(ICourseRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<CourseResDto> Get(CourseQueryObject query)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IQueryable<Course> res = _repo.Get(query);
            //get all items count before apply pagination
            int count = await GetCountAsync(res);

            //then get filtered items paged list
            var pagedCourses = await GetPagedStudentsAsync(res, query);
            var items = _mapper.Map<List<CourseDto>>(pagedCourses);

            stopwatch.Stop();
            String excutionDuration = stopwatch.Elapsed.TotalSeconds + " sec";


            var studentResDto = new CourseResDto
            {
                TotalCount = count,
                ExcutionDuration = excutionDuration,
                Items = items
            };

            //return standard res
            return studentResDto;
        }

        public async Task<CourseDto?> GetById(int id)
        {
            var course = await _repo.GetById(id);
            if (course == null)
            {
                return null;
            }
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task<bool> Delete(int id)
        {
            bool res = await _repo.Delete(id);
            return res;
        }

        public async Task<CourseDto?> Create(CreateCourseInput input)
        {
            Course course = _mapper.Map<Course>(input);
            Course? created = await _repo.Create(course);
            if (created == null)
                return null;
            CourseDto createdCourseDto = _mapper.Map<CourseDto>(created);
            return createdCourseDto;
        }

    }
}