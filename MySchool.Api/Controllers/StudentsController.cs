using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Myschool.Application.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto student)
        {
           await _studentService.Add(student);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(StudentDto student)
        {
            await _studentService.Update(student);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(StudentDto student)
        {
            await _studentService.Delete(student);
            return Ok();
        }
    }
}
