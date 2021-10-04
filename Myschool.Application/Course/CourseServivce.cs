using AutoMapper;
using Myschool.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Course
{
    public class CourseServivce: ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseServivce(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public Task Add(CourseDto course)
        {
            return _courseRepository.Add(_mapper.Map<Myschool.Domain.Entites.Course>(course));
        }
        public async Task<List<CourseDto>> Get(Expression<Func<CourseDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Myschool.Domain.Entites.Course, bool>>>(filter);
            var result = await _courseRepository.Get(dtoFilter);
            return _mapper.Map<List<CourseDto>>(result);
        }
        public Task Delete(CourseDto course)
        {
            return _courseRepository.Delete(_mapper.Map<Myschool.Domain.Entites.Course>(course));
        }
        public Task Update(CourseDto course)
        {
            return _courseRepository.Update(_mapper.Map<Myschool.Domain.Entites.Course>(course));
        }

        public async Task<List<CourseDto>> GetAll()
        {
            var result=await _courseRepository.GetAll();
            return _mapper.Map<List<CourseDto>>(result); 
        }

        public async Task<List<CourseDto>> GetCourseByTeacher(Guid id)
        {
            var result = await _courseRepository.GetCourseByTeacher(id);
            return _mapper.Map<List<CourseDto>>(result);
        }
    }
}
