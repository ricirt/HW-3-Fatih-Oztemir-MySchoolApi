using Microsoft.Extensions.DependencyInjection;
using Myschool.Application.Course;
using Myschool.Application.Student;
using Myschool.Application.Teacher;
using Myschool.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Extensions
{
    public static class ApplicationModuleExtension
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddInfrastructure();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseServivce>();
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
