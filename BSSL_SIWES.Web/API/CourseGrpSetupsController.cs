using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGrpSetupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseGrpSetupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseGrpSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseGrpSetup>>> GetCourseGrpSetup()
        {
            return await _context.CourseGrpSetup.ToListAsync();
        }

        // GET: api/CourseGrpSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseGrpSetup>> GetCourseGrpSetup(int id)
        {
            var courseGrpSetup = await _context.CourseGrpSetup.FindAsync(id);

            if (courseGrpSetup == null)
            {
                return NotFound();
            }

            return courseGrpSetup;
        }

        // PUT: api/CourseGrpSetups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseGrpSetup(int id, CourseGrpSetup courseGrpSetup)
        {
            if (id != courseGrpSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(courseGrpSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseGrpSetupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(courseGrpSetup);
        }

        // POST: api/CourseGrpSetups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CourseGrpSetup>> PostCourseGrpSetup(CourseGrpSetup courseGrpSetup)
        {
            _context.CourseGrpSetup.Add(courseGrpSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseGrpSetup", new { id = courseGrpSetup.Id }, courseGrpSetup);
        }

        // DELETE: api/CourseGrpSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseGrpSetup>> DeleteCourseGrpSetup(int id)
        {
            var courseGrpSetup = await _context.CourseGrpSetup.FindAsync(id);
            if (courseGrpSetup == null)
            {
                return NotFound();
            }

            _context.CourseGrpSetup.Remove(courseGrpSetup);
            await _context.SaveChangesAsync();

            return courseGrpSetup;
        }

        private bool CourseGrpSetupExists(int id)
        {
            return _context.CourseGrpSetup.Any(e => e.Id == id);
        }
    }
}
