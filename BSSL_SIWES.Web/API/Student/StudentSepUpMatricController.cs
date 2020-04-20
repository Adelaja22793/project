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
    public class StudentSepUpMatricController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentSepUpMatricController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentSepUpMatric
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSetUp>>> GetStudentSetUps()
        {
            return await _context.StudentSetUps.ToListAsync();
        }

        // GET: api/StudentSepUpMatric/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSetUp>> GetStudentSetUp(string matricNo)
        {
            //var studentSetUp = await _context.StudentSetUps.FindAsync(id);
            var studentId = await _context.StudentSetUps.Include(x => x.Courses)
                   .Include(x => x.InstitutionOfficer).ThenInclude(x => x.Institution)
                    .Where(x => x.MatricNumber == matricNo && x.Courses.Id == x.CoursesId 
                    && x.InstitutionOfficer.Institution.Id == x.InstitutionOfficer.InstitutionId).FirstOrDefaultAsync(x => x.MatricNumber == matricNo);

            //if (studentId == null)
            //{
            //    return NotFound($"Student Not Found For The Selected Id {id}");
            //}
            return Ok(studentId);
            
        }

        // PUT: api/StudentSepUpMatric/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentSetUp(int? id, StudentSetUp studentSetUp)
        {
            if (id == null)
            {
                return BadRequest("No Student Found Selected");
            }

            try
            {
                var updateStudentRecords = await _context.StudentSetUps.FirstOrDefaultAsync(m => m.Id == id);

                if (updateStudentRecords == null)
                {
                    return NotFound($"Student Not Found For The Selected Id {id}");
                }
                updateStudentRecords.Surname = studentSetUp.Surname;
                updateStudentRecords.OtherNames = studentSetUp.OtherNames;
                updateStudentRecords.MatricNumber = studentSetUp.MatricNumber;
                updateStudentRecords.MatricYear = studentSetUp.MatricYear;

                updateStudentRecords.CoursesId = studentSetUp.CoursesId;
                updateStudentRecords.YearOfStudy = studentSetUp.YearOfStudy;
                updateStudentRecords.PhoneNo = studentSetUp.PhoneNo;
                updateStudentRecords.Email = studentSetUp.Email;

                updateStudentRecords.BatchNo = studentSetUp.BatchNo;
                updateStudentRecords.StudentType = studentSetUp.StudentType;
                updateStudentRecords.SiwesYear = studentSetUp.SiwesYear;
                //updateStudentRecords.InstitutionOfficerId = studentSetUp.InstitutionOfficerId;

                updateStudentRecords.LGAId = studentSetUp.LGAId;
                //updateStudentRecords.S = studentSetUp.SiwesYear;
                //updateStudentRecords.InstitutionOfficerId = studentSetUp.InstitutionOfficerId;
                await _context.SaveChangesAsync();
                return Ok(updateStudentRecords);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/StudentSepUpMatric
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudentSetUp>> PostStudentSetUp(StudentSetUp studentSetUp)
        {
            _context.StudentSetUps.Add(studentSetUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentSetUp", new { id = studentSetUp.Id }, studentSetUp);
        }

        // DELETE: api/StudentSepUpMatric/5
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
