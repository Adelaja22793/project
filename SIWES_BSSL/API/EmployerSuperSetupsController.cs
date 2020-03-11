using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIWES_BSSL.Data;
using SIWES_BSSL.Data.Employer;

namespace SIWES_BSSL.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerSuperSetupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployerSuperSetupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployerSuperSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployerSuperSetup>>> GetEmployerSuperSetups()
        {
            return await _context.EmployerSuperSetups.ToListAsync();
            //return await _context.EmployerSuperSetups.Include(x => x.AreaOffice)
            //    .Where(x => x.AreaOffice.Id == x.AreaOfficeId).FirstOrDefaultAsync(x => x.Id == id);
        }

        // GET: api/EmployerSuperSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerSuperSetup>> GetEmployerSuperSetup(int id)
        {
            var employerSuperSetup = await _context.EmployerSuperSetups.Include(x =>x.AreaOffice)
                .Where(x => x.AreaOffice.Id == x.AreaOfficeId).FirstOrDefaultAsync(x =>x.Id == id);

            if (employerSuperSetup == null)
            {
                return NotFound();
            }

            return employerSuperSetup;
        }

        // PUT: api/EmployerSuperSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployerSuperSetup(int id, EmployerSuperSetup employerSuperSetup)
        {
            if (id != employerSuperSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(employerSuperSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerSuperSetupExists(id))
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

        // POST: api/EmployerSuperSetups
        [HttpPost]
        public async Task<ActionResult<EmployerSuperSetup>> PostEmployerSuperSetup(EmployerSuperSetup employerSuperSetup)
        {
            _context.EmployerSuperSetups.Add(employerSuperSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployerSuperSetup", new { id = employerSuperSetup.Id }, employerSuperSetup);
        }

        // DELETE: api/EmployerSuperSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployerSuperSetup>> DeleteEmployerSuperSetup(int id)
        {
            var employerSuperSetup = await _context.EmployerSuperSetups.FindAsync(id);
            if (employerSuperSetup == null)
            {
                return NotFound();
            }

            _context.EmployerSuperSetups.Remove(employerSuperSetup);
            await _context.SaveChangesAsync();

            return employerSuperSetup;
        }

        private bool EmployerSuperSetupExists(int id)
        {
            return _context.EmployerSuperSetups.Any(e => e.Id == id);
        }
    }
}
