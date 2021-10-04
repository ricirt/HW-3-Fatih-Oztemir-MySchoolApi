using Myschool.Domain.Entites;
using Myschool.Domain.Repositories;
using Myschool.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Infrastructure.Repositories
{
    public class CourseRepository:Repositories<Course> ,ICourseRepository
    {
        private readonly SchoolDbContext _context;
        public CourseRepository(SchoolDbContext dbContext):base(dbContext)
        {
            _context = dbContext;
        }

        public  Task<List<Course>> GetCourseByTeacher(Guid id)
        {
            var result = (from c in _context.Courses
                          join t in _context.Teachers
                          on c.TeacherId equals t.Id
                          select new Course
                          {
                              Id = c.Id,
                              IsActive = c.IsActive,
                              TeacherId = t.Id,
                              Name = c.Name
                          });
            return Task.FromResult(result.ToList());
        }
    }
}
