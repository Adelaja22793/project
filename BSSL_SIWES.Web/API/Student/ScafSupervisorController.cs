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
    public class ScafSupervisorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScafSupervisorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ScafSupervisor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scaf>>> GetScafs()
        {
            return await _context.Scafs.ToListAsync();
        }

        // GET: api/ScafSupervisor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scaf>> GetScaf(int id)
        {
            var scaf = await _context.Scafs.Include(x => x.EmployerSupervisor).ThenInclude(x => x.EmployerSuperSetup)
                //.ThenInclude(x =>x.)
                .Where(x => x.EmployerSupervisorId == x.EmployerSupervisor.Id 
                && x.EmployerSupervisor.EmployerSuperSetup.Id == x.EmployerSupervisor.EmployerSuperSetupId && x.StudentSetUpId == id).SingleOrDefaultAsync();

            if (scaf == null)
            {
                return NotFound("THE SELECTED STUDENT HAVE NOT BEEN ATTACHED/ACCEPTED BY EMPLOYER");
            }

            return scaf;
            //var scaf = await _context.Scafs.FindAsync(id);

            //if (scaf == null)
            //{
            //    return NotFound();
            //}

            //return scaf;
        }

        // PUT: api/ScafSupervisor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScaf(int id, Scaf scaf)
        {
            if (id != scaf.Id)
            {
                return BadRequest();
            }

            _context.Entry(scaf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScafExists(id))
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

        // POST: api/ScafSupervisor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Scaf>> PostScaf(Scaf scaf)
        {
            _context.Scafs.Add(scaf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScaf", new { id = scaf.Id }, scaf);
        }

        // DELETE: api/ScafSupervisor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scaf>> DeleteScaf(int id)
        {
            var scaf = await _context.Scafs.FindAsync(id);
            if (scaf == null)
            {
                return NotFound();
            }

            _context.Scafs.Remove(scaf);
            await _context.SaveChangesAsync();

            return scaf;
        }

        private bool ScafExists(int id)
        {
            return _context.Scafs.Any(e => e.Id == id);
        }
    }
}
