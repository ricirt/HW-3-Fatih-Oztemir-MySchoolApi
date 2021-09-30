using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Course
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDto, Myschool.Domain.Entites.Course>().ReverseMap();
        }
    }
}
