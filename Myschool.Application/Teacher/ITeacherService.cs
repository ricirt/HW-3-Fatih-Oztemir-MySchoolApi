using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Teacher
{
    public interface ITeacherService
    {
        Task Add(TeacherDto teacher);
        public Task<List<TeacherDto>> Get(Expression<Func<TeacherDto, bool>> filter);
        Task Delete(TeacherDto teacher);
        Task Update(TeacherDto teacher);
        Task<List<TeacherDto>> GetAll();
        Task<TeacherDto> GetByCourse(Guid courseId);

    }
}
