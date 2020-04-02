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
    public class ScafsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScafsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Scafs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scaf>>> GetScafs()
        {
            return await _context.Scafs.ToListAsync();
        }

        // GET: api/Scafs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scaf>> GetScaf(int? id)
        {
            if (id == null)
            {
                return BadRequest("Student ID is Empty");
            }
            try
            {
                 var  Scafs = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
              .Where(x => x.EmployerSupervisorId == id && x.Suspended == false).ToListAsync();
                if(Scafs == null)
                {
                    return NotFound($"Student Not Found For The Selected Id {id}");
                }
                return Ok(Scafs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Scafs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScaf(int? id, Scaf scaf)
        {
            if (id == null)
            {
                return BadRequest("StudentId is Empty");
            }

            try
            {
                var newScaf = await _context.Scafs.FirstOrDefaultAsync(m => m.Id == id);

                if (newScaf == null)
                {
                    return NotFound($"Student Not Found For The Selected Id {id}");
                }
                newScaf.Suspended = scaf.Suspended = true;
                newScaf.ReasonSuspended = scaf.ReasonSuspended;
                await _context.SaveChangesAsync();
                return Ok(newScaf);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // POST: api/Scafs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Scaf>> PostScaf(Scaf scaf)
        {
            _context.Scafs.Add(scaf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScaf", new { id = scaf.Id }, scaf);
        }

        // DELETE: api/Scafs/5
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
