using Microsoft.EntityFrameworkCore;
using Myschool.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Infrastructure.Context
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions options):base(options)
        {
             
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
