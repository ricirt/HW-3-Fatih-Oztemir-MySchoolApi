using Myschool.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Domain.Repositories
{
    public interface ITeacherRepository:IRepository<Teacher>
    {
        Task<Teacher> GetByCourse(Guid courseId);
    }
}
