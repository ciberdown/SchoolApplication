using SchoolApplication.src.Dtos.Course;

namespace SchoolApplication.src.Interfaces
{
    public interface ICourseAppService
    {
        public Task<CourseResDto> Get(CourseQueryObject qeury);
        public Task<CourseDto?> GetById(int id);
        public Task<bool> Delete(int id);

        public Task<CourseDto?> Create(CreateCourseInput input);

    }
}