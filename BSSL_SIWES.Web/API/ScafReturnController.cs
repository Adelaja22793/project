using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Students;

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScafReturnController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScafReturnController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ScafReturn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scaf>>> GetScafs()
        {
            return await _context.Scafs.ToListAsync();
        }

        // GET: api/ScafReturn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scaf>> GetScaf(int id)
        {
            var scaf = await _context.Scafs.Include(x =>x.EmployerSupervisor).Include(x => x.StudentSetUp).ThenInclude(x =>x.Courses)
                //.ThenInclude(x =>x.)
                .Where(x =>x.EmployerSupervisorId == x.EmployerSupervisor.Id && x.StudentSetUpId == id 
                && x.StudentSetUp.CoursesId == x.StudentSetUp.Courses.Id).SingleOrDefaultAsync();

            //if (scaf == null)
            //{
            //    return NotFound();
            //}

            return scaf;
        }

        // PUT: api/ScafReturn/5
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

        // POST: api/ScafReturn
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Scaf>> PostScaf(Scaf scaf)
        {
            _context.Scafs.Add(scaf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScaf", new { id = scaf.Id }, scaf);
        }

        // DELETE: api/ScafReturn/5
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
