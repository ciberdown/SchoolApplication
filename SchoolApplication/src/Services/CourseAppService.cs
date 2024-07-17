using AutoMapper;
using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Services
{
    public abstract class CourseAppServiceBase : ICourseAppService
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
            IQueryable<Course> res = _repo.Get(query);
            //get all items count before apply pagination
            int count = await GetCountAsync(res);

            //then get filtered items paged list
            var pagedCourses = await GetPagedStudentsAsync(res, query);

            var studentResDto = new CourseResDto
            {
                TotalCount = count,
                Items = _mapper.Map<List<CourseDto>>(pagedCourses)
            };
            var Items = _mapper.Map<List<CourseDto>>(pagedCourses);

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


        protected async Task<int> GetCountAsync(IQueryable<Course> query)
        {
            return await query.GetCountAsync();
        }

        protected async Task<List<Course>> GetPagedStudentsAsync(IQueryable<Course> query, PaginationQueryObject paginationQueryObject)
        {
            return await query.GetPagedAsync(paginationQueryObject);
        }


    }
}