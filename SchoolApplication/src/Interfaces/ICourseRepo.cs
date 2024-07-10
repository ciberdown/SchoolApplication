using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApplication.src.Dtos.Course;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface ICourseRepo
    {
        public IQueryable<Course> Get(CourseQueryObject query);
        public Task<Course?> GetById(int id);

    }
}