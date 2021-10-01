using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Student
{
    public interface IStudentService
    {
        Task Add(StudentDto student);
        public Task<List<StudentDto>> Get(Expression<Func<StudentDto, bool>> filter);
        Task Delete(StudentDto student);
        Task Update(StudentDto student);
        Task<List<StudentDto>> GetAll();
    }
}
