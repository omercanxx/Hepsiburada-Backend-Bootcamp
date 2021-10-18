using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Odev01API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Odev01API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private static List<CourseDto> _courseList;

        public CourseController()
        {
            _courseList = new List<CourseDto>();
            for (int i = 1; i <= 10; i++)
            {
                _courseList.Add(new CourseDto(i, $"{i}. Kurs", (i + 20) * 2));
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto course)
        {
            _courseList.Add(course);
            if (ModelState.IsValid)
            {
                return Ok(course);
            }
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseUpdateDto request)
        {
            var dbCourse = _courseList.FirstOrDefault(x => x.Id == request.Id);
            if (dbCourse != null)
            {
                dbCourse.UpdateTitle(request.Title);
                dbCourse.UpdatePrice(request.Price);
                if (ModelState.IsValid)
                {
                    return Ok(dbCourse);
                }
                else
                    return BadRequest();
            }

            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return await Task.FromResult(Ok(_courseList.Where(x => x.IsActive)));
        }

        [HttpGet("&lowestFirst={lowestFirst}")]
        public async Task<IActionResult> GetCoursesLowestFirst(bool lowestFirst)
        {
            if (lowestFirst == true)
                _courseList = _courseList.OrderBy(x => x.Price).ToList();

            else
                _courseList = _courseList.OrderByDescending(x => x.Price).ToList();


            return await Task.FromResult(Ok(_courseList.Where(x => x.IsActive)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseDetail(int id)
        {
            var dbCourse = _courseList.FirstOrDefault(x => x.Id == id); 
            
            if (dbCourse != null)
            {
                return Ok(dbCourse);
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var dbCourse = _courseList.FirstOrDefault(x => x.Id == id);
            if (dbCourse != null)
            {
                dbCourse.UpdateActivation(false);
                return Ok(dbCourse);
            }

            else
                return NotFound();
        }
    }
}
