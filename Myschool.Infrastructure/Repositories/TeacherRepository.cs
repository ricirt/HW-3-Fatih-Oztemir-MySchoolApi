using Microsoft.EntityFrameworkCore;
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
    public class TeacherRepository : Repositories<Teacher>, ITeacherRepository
    {
        private readonly SchoolDbContext _context;
        public TeacherRepository(SchoolDbContext dbContext):base(dbContext)
        {
            _context = dbContext;
        } 
        //özel methodlar buraya yazlır.
        public async Task<Teacher> GetByCourse(Guid courseId)
        {
            //var result = await _context.Teachers.Include(t => t.Courses).ToListAsync();
            //return result;

            var result = await (from t in _context.Teachers
                          join c in _context.Courses
                          on t.Id equals c.TeacherId
                          select new Teacher
                          {
                              Id = t.Id,
                              Name = t.Name,
                              LastName = t.LastName,
                          }).FirstOrDefaultAsync();
            return (result);
        }

        Task<List<Teacher>> ITeacherRepository.GetByCourse(Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}
