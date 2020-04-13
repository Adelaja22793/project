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
    public class MonthlyAssessmentSuperController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MonthlyAssessmentSuperController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MonthlyAssessmentSuper
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthlyAssessment>>> GetMonthlyAssessments()
        {
            return await _context.MonthlyAssessments.ToListAsync();
        }

        // GET: api/MonthlyAssessmentSuper/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyAssessment>> GetMonthlyAssessment(int? id)
        {
            if (id == null)
            {
                return BadRequest("No Monthly Assessment Record For This Student");
            }
            try
            {
                var dailyActivitiesList = await _context.MonthlyAssessments
                    .Where(x => x.StudentSetUpId == id && x.Approved == false).ToListAsync();



                if (dailyActivitiesList == null)
                {
                    return NotFound($"Monthly Assessment Not Found For The Selected Id {id}");
                }
                return Ok(dailyActivitiesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/MonthlyAssessmentSuper/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlyAssessment(int id, MonthlyAssessment monthlyAssessment)
        {
            if (id != monthlyAssessment.Id)
            {
                return BadRequest();
            }

            _context.Entry(monthlyAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyAssessmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MonthlyAssessmentSuper
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MonthlyAssessment>> PostMonthlyAssessment(MonthlyAssessment monthlyAssessment)
        {
            _context.MonthlyAssessments.Add(monthlyAssessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthlyAssessment", new { id = monthlyAssessment.Id }, monthlyAssessment);
        }

        // DELETE: api/MonthlyAssessmentSuper/5
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
