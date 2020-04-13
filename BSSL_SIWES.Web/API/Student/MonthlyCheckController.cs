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
    public class MonthlyCheckController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MonthlyCheckController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MonthlyCheck
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthlyAssessment>>> GetMonthlyAssessments()
        {
            return await _context.MonthlyAssessments.ToListAsync();
        }

        // GET: api/MonthlyCheck/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyAssessment>> GetMonthlyAssessment(int? id)
        {
            if (id == null)
            {
                return BadRequest("Student ID is Empty");
            }
            try
            {
                var monthlyAss = await _context.MonthlyAssessments.Include(x => x.StudentSetUp)
                    .Where(x => x.StudentSetUpId == id).ToListAsync();

                if (monthlyAss == null)
                {
                    return NotFound($"Student Not Found For The Selected Id {id}");
                }
                return Ok(monthlyAss);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/MonthlyCheck/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlyAssessment(int? id, MonthlyAssessment monthlyAssessment)
        {
            if (id == null)
            {
                return BadRequest("No Activity Found");
            }

            try
            {
                var updateMonthlyAssessment = await _context.MonthlyAssessments.FirstOrDefaultAsync(m => m.Id == id);

                if (updateMonthlyAssessment == null)
                {
                    return NotFound($"Monthly Assessment Not Found For The Selected Id {id}");
                }
                updateMonthlyAssessment.MonthlyRemarksByStudent = monthlyAssessment.MonthlyRemarksByStudent;
                await _context.SaveChangesAsync();
                return Ok(updateMonthlyAssessment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/MonthlyCheck
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MonthlyAssessment>> PostMonthlyAssessment(MonthlyAssessment monthlyAssessment)
        {
            _context.MonthlyAssessments.Add(monthlyAssessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthlyAssessment", new { id = monthlyAssessment.Id }, monthlyAssessment);
        }

        // DELETE: api/MonthlyCheck/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MonthlyAssessment>> DeleteMonthlyAssessment(int id)
        {
            var monthlyAssessment = await _context.MonthlyAssessments.FindAsync(id);
            if (monthlyAssessment == null)
            {
                return NotFound();
            }

            _context.MonthlyAssessments.Remove(monthlyAssessment);
            await _context.SaveChangesAsync();

            return monthlyAssessment;
        }

        private bool MonthlyAssessmentExists(int id)
        {
            return _context.MonthlyAssessments.Any(e => e.Id == id);
        }
    }
}
