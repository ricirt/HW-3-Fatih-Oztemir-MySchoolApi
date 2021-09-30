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
        public TeacherRepository(SchoolDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
