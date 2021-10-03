using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Myschool.Application.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _teacherService.Get(_ => true);
            return Ok(new { status = true, data = result });
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherDto teacher)
        {
            await _teacherService.Add(teacher);
            return Ok();
        }
    }
}
