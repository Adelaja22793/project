using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;
using SiwesData.Students;

namespace BSSL_SIWES.Web.API.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSetUpsController : ControllerBase
    {
        public Institution Institution { get; set; }
        public class StudentsViewModel
        {
            public bool Suspended { get; set; }
        }
        private readonly ApplicationDbContext _context;

        public StudentSetUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentSetUps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSetUp>>> GetStudentSetUps()
        {
            return await _context.StudentSetUps.ToListAsync();
        }

        // GET: api/StudentSetUps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSetUp>> GetStudentSetUp(int? id)
        {
            if (id == null)
            {
                return BadRequest("StudentId is Empty");
            }
            try
            {
                //var studentId = await _context.StudentSetUps.Include(x => x.Courses).Include(x =>x.LGA)
                //    .ThenInclude(x =>x.State).ThenInclude(x =>x.Nationality)
                //    .Include(x => x.InstitutionOfficer).ThenInclude(x =>x.Institution)
                //     .Where(x => x.Id == id && x.Courses.Id == x.CoursesId && x.LGAId == x.LGA.Id ).FirstOrDefaultAsync(x => x.Id == id);
                //&& x.LGA.StateId == x.LGA.State.Id && x.LGA.State.NationalityId == x.LGA.State.Nationality.Id
                var studentId = await _context.StudentSetUps.Include(x => x.Courses)
                    .Include(x => x.InstitutionOfficer).ThenInclude(x => x.Institution)
                     .Where(x => x.Id == id && x.Courses.Id == x.CoursesId && x.InstitutionOfficer.Institution.Id == x.InstitutionOfficer.InstitutionId).FirstOrDefaultAsync(x => x.Id == id);

                if (studentId == null)
                {
                    return NotFound($"Student Not Found For The Selected Id {id}");
                }
                return Ok(studentId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // PUT: api/StudentSetUps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentSetUp(int? id, StudentSetUp suspendStudent)
        {
            if (id == null)
            {
                return BadRequest("StudentId is Empty");
            }

            try
            {
                var studentSuspended = await _context.StudentSetUps.FirstOrDefaultAsync(m => m.Id == id);

                if (studentSuspended == null)
                {
                    return NotFound($"Student Not Found For The Selected Id {id}");
                }
                //bool nowSuspend = suspendStudent.Suspended = true;
                studentSuspended.Suspended = suspendStudent.Suspended = true;
                studentSuspended.ReasonSuspended = suspendStudent.ReasonSuspended;

                await _context.SaveChangesAsync();
                return Ok(studentSuspended);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // POST: api/StudentSetUps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudentSetUp>> PostStudentSetUp(StudentSetUp studentSetUp)
        {
            _context.StudentSetUps.Add(studentSetUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentSetUp", new { id = studentSetUp.Id }, studentSetUp);
        }

        // DELETE: api/StudentSetUps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentSetUp>> DeleteStudentSetUp(int id)
        {
            var studentSetUp = await _context.StudentSetUps.FindAsync(id);
            if (studentSetUp == null)
            {
                return NotFound();
            }

            _context.StudentSetUps.Remove(studentSetUp);
            await _context.SaveChangesAsync();

            return studentSetUp;
        }

        private bool StudentSetUpExists(int id)
        {
            return _context.StudentSetUps.Any(e => e.Id == id);
        }
    }
}
