using AutoMapper;
using Myschool.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Teacher
{
    public class TeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository,IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public Task Add(TeacherDto teacher)
        {
            return _teacherRepository.Add(_mapper.Map<Myschool.Domain.Entites.Teacher>(teacher));
        }
        public async Task<List<TeacherDto>> Get(Expression<Func<TeacherDto,bool>> filter)
        {
            var dtoFilter=_mapper.Map<Expression<Func<Myschool.Domain.Entites.Teacher, bool>>>(filter);
            var result= await _teacherRepository.Get(dtoFilter);
            return _mapper.Map<List<TeacherDto>>(result);
        }
        public Task Delete(TeacherDto teacher)
        {
            return _teacherRepository.Delete(_mapper.Map<Myschool.Domain.Entites.Teacher>(teacher));
        }
        public Task Update(TeacherDto teacher)
        {
            return _teacherRepository.Update(_mapper.Map<Myschool.Domain.Entites.Teacher>(teacher));
        }
    }
}
