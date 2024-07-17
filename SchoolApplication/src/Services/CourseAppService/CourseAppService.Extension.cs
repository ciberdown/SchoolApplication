using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;

namespace SchoolApplication.src.Services.CourseAppService
{
    public class CourseAppService : CourseAppServiceBase, ICourseAppService
    {
        public CourseAppService(ICourseRepo repo, IMapper mapper) : base(repo, mapper)
        {

        }
    }
}