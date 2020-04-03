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
    public class AgencySuperSetupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AgencySuperSetupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AgencySuperSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencySuperSetup>>> GetAgencySuperSetup()
        {
            return await _context.AgencySuperSetup.ToListAsync();
        }

        // GET: api/AgencySuperSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgencySuperSetup>> GetAgencySuperSetup(int id)
        {
            var agencySuperSetup = await _context.AgencySuperSetup.FindAsync(id);

            if (agencySuperSetup == null)
            {
                return NotFound();
            }

            return agencySuperSetup;
        }

        // PUT: api/AgencySuperSetups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencySuperSetup(int id, AgencySuperSetup agencySuperSetup)
        {
            if (id != agencySuperSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(agencySuperSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgencySuperSetupExists(id))
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

        // POST: api/AgencySuperSetups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AgencySuperSetup>> PostAgencySuperSetup(AgencySuperSetup agencySuperSetup)
        {
           // updateCourse.Name = editCourses.CourseName;
            _context.AgencySuperSetup.Add(agencySuperSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgencySuperSetup", new { id = agencySuperSetup.Id }, agencySuperSetup);
        }

        // DELETE: api/AgencySuperSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgencySuperSetup>> DeleteAgencySuperSetup(int id)
        {
            var agencySuperSetup = await _context.AgencySuperSetup.FindAsync(id);
            if (agencySuperSetup == null)
            {
                return NotFound();
            }

            _context.AgencySuperSetup.Remove(agencySuperSetup);
            await _context.SaveChangesAsync();

            return agencySuperSetup;
        }

        private bool AgencySuperSetupExists(int id)
        {
            return _context.AgencySuperSetup.Any(e => e.Id == id);
        }
    }
}
