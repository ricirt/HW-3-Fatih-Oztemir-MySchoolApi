using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Course
{
    public interface ICourseService
    {
        Task Add(CourseDto student);
        public Task<List<CourseDto>> Get(Expression<Func<CourseDto, bool>> filter);
        Task Delete(CourseDto student);
        Task Update(CourseDto student);
        Task<List<CourseDto>> GetAll();
        Task<List<CourseDto>> GetCourseByTeacher(Guid id);
    }
}
