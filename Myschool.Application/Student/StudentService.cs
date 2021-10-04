using AutoMapper;
using Myschool.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Application.Student
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public Task Add(StudentDto student)
        {
            return _studentRepository.Add(_mapper.Map<Myschool.Domain.Entites.Student>(student));
        }
        public async Task<List<StudentDto>> Get(Expression<Func<StudentDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Myschool.Domain.Entites.Student, bool>>>(filter);
            var result = await _studentRepository.Get(dtoFilter);
            return _mapper.Map<List<StudentDto>>(result);
        }
        public Task Delete(StudentDto student)
        {
            return _studentRepository.Delete(_mapper.Map<Myschool.Domain.Entites.Student>(student));
        }
        public Task Update(StudentDto student)
        {
            return _studentRepository.Update(_mapper.Map<Myschool.Domain.Entites.Student>(student));
        }

        public async Task<List<StudentDto>> GetAll()
        {
            var result = await _studentRepository.GetAll();
            var mappedResult = _mapper.Map<List<StudentDto>>(result);
            return mappedResult;
        }
    }
}
