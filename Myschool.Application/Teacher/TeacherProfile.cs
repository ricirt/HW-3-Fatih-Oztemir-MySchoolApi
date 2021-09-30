using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Teacher
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDto, Myschool.Domain.Entites.Teacher>().ReverseMap();
        }
    }
}
