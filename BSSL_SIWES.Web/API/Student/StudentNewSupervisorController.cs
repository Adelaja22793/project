using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Students;

namespace BSSL_SIWES.Web.API.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentNewSupervisorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentNewSupervisorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentNewSupervisor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSetUp>>> GetStudentSetUps()
        {
            return await _context.StudentSetUps.ToListAsync();
        }

        // GET: api/StudentNewSupervisor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSetUp>> GetStudentSetUp(int id)
        {
            var studentSetUp = await _context.StudentSetUps.FindAsync(id);

            if (studentSetUp == null)
            {
                return NotFound();
            }

            return studentSetUp;
        }

        // PUT: api/StudentNewSupervisor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentSetUp(int? id, StudentSetUp studentSetUp)
        {
            if (id == null)
            {
                return BadRequest("StudentId is Empty");
            }

            try
            {
                var InstitutionOfficer = await _context.StudentSetUps.FirstOrDefaultAsync(m => m.Id == id);

                if (InstitutionOfficer == null)
                {
                    return NotFound($"Student Not Found For The Selected Id {id}");
                }
                //bool nowSuspend = suspendStudent.Suspended = true;
                InstitutionOfficer.InstitutionOfficerId = studentSetUp.InstitutionOfficerId;
                InstitutionOfficer.OldInstitutionOfficerId = InstitutionOfficer.InstitutionOfficerId;
                InstitutionOfficer.DateChanged = DateTime.Now;

                await _context.SaveChangesAsync();
                return Ok(InstitutionOfficer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/StudentNewSupervisor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudentSetUp>> PostStudentSetUp(StudentSetUp studentSetUp)
        {
            _context.StudentSetUps.Add(studentSetUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentSetUp", new { id = studentSetUp.Id }, studentSetUp);
        }

        // DELETE: api/StudentNewSupervisor/5
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
