using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web.API.Courses_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public class CourseViewModel
        {
            public string CourseName { get; set; }
            public string CourseCode { get; set; }
            public string ShortCode { get; set; }
            public int CourseGrpId { get; set; }
        }

        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Courses>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Courses>> GetCourses(int id)
        {
            var courses = await _context.Courses.FindAsync(id);

            if (courses == null)
            {
                return NotFound();
            }

            return courses;
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourses(int? id, CourseViewModel editCourses)
        {
            if (id == null)
            {
                return BadRequest("CourseId is Empty");
            }

            try
            {
                var updateCourse = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);

                if (updateCourse == null)
                {
                    return NotFound($"Course Not Found For The Selected Id {id}");
                }
                updateCourse.Name = editCourses.CourseName;
                updateCourse.ShortCode = editCourses.ShortCode;
                updateCourse.CourseGrpSetupId = editCourses.CourseGrpId;

                await _context.SaveChangesAsync();
                return Ok(updateCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //if (id != courses.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(courses).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CoursesExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<Courses>> PostCourses(CourseViewModel myCourses)
        {
            try
            {
                
                var newCourse = new Courses
                {
                    Code = myCourses.CourseCode, 
                    ShortCode = myCourses.ShortCode,
                    Name = myCourses.CourseName,
                    CourseGrpSetupId = myCourses.CourseGrpId
                };
                _context.Courses.Add(newCourse);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostCourses", new { id = newCourse.Id }, newCourse);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, $"{myCourses.CourseName.ToUpper()} HAS ALREADY BEEN SETUP");
            }
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Courses>> DeleteCourses(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courses);
            await _context.SaveChangesAsync();

            return courses;
        }

        private bool CoursesExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
