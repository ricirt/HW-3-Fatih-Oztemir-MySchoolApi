using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Myschool.Application.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseDto course)
        {
            await _courseService.Add(course);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseDto course)
        {
            await _courseService.Update(course);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(CourseDto course)
        {
            await _courseService.Delete(course);
            return Ok();
        }
    }
}
