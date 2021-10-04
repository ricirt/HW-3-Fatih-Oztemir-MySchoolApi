using AutoMapper.QueryableExtensions;
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
        public async Task<IActionResult> Get(Guid id)
        {
            var query = await _teacherService.Get(i=>i.Id==id); // entities query
            return Ok(query);

            //var result = await _teacherService.Get(t=>t.Id==id);
           // return Ok(new { status = true, data = result });
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherDto teacher)
        {
            await _teacherService.Add(teacher);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(TeacherDto teacher)
        {
            await _teacherService.Delete(teacher);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(TeacherDto teacher)
        {
            await _teacherService.Update(teacher);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<TeacherDto> result=await _teacherService.GetAll();
            return Ok(result);
        }
    }
}
