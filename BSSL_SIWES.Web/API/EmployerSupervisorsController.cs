using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Employer;

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerSupervisorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployerSupervisorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployerSupervisors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployerSupervisor>>> GetEmployerSupervisors()
        {
            return await _context.EmployerSupervisors.ToListAsync();
        }

        // GET: api/EmployerSupervisors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerSupervisor>> GetEmployerSupervisor(int id)
        {

            var employerSupervisor = await _context.EmployerSupervisors.Include(x => x.EmployerSuperSetup)
                   .Where(x => x.EmployerSuperSetupId == x.EmployerSuperSetup.Id && x.Id == id)
                   .FirstOrDefaultAsync();

            //if (studentId == null)
            //{
            //    return NotFound($"Student Not Found For The Selected Id {id}");
            //}
            return Ok(employerSupervisor);

            //var employerSupervisor = await _context.EmployerSupervisors.FindAsync(id);

            //if (employerSupervisor == null)
            //{
            //    return NotFound();
            //}

            //return employerSupervisor;
        }

        // PUT: api/EmployerSupervisors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployerSupervisor(int id, EmployerSupervisor employerSupervisor)
        {
            if (id != employerSupervisor.Id)
            {
                return BadRequest();
            }

            _context.Entry(employerSupervisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerSupervisorExists(id))
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

        // POST: api/EmployerSupervisors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployerSupervisor>> PostEmployerSupervisor(EmployerSupervisor employerSupervisor)
        {
            _context.EmployerSupervisors.Add(employerSupervisor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployerSupervisor", new { id = employerSupervisor.Id }, employerSupervisor);
        }

        // DELETE: api/EmployerSupervisors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployerSupervisor>> DeleteEmployerSupervisor(int id)
        {
            var employerSupervisor = await _context.EmployerSupervisors.FindAsync(id);
            if (employerSupervisor == null)
            {
                return NotFound();
            }

            _context.EmployerSupervisors.Remove(employerSupervisor);
            await _context.SaveChangesAsync();

            return employerSupervisor;
        }

        private bool EmployerSupervisorExists(int id)
        {
            return _context.EmployerSupervisors.Any(e => e.Id == id);
        }
    }
}
