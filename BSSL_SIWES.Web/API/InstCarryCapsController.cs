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
    public class InstCarryCapsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstCarryCapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InstCarryCaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstCarryCap>>> GetInstCarryCap()
        {
            return await _context.InstCarryCap.ToListAsync();
        }

        // GET: api/InstCarryCaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstCarryCap>> GetInstCarryCap(int id)
        {
            var instCarryCap = await _context.InstCarryCap.FindAsync(id);

            if (instCarryCap == null)
            {
                return NotFound();
            }

            return instCarryCap;
        }

        // PUT: api/InstCarryCaps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstCarryCap(int id, InstCarryCap instCarryCap)
        {
            if (id != instCarryCap.Id)
            {
                return BadRequest();
            }

            _context.Entry(instCarryCap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstCarryCapExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(instCarryCap);
        }

        // POST: api/InstCarryCaps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InstCarryCap>> PostInstCarryCap(InstCarryCap instCarryCap)
        {
           
            _context.InstCarryCap.Add(instCarryCap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstCarryCap", new { id = instCarryCap.Id }, instCarryCap);
        }

        // DELETE: api/InstCarryCaps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstCarryCap>> DeleteInstCarryCap(int id)
        {
            var instCarryCap = await _context.InstCarryCap.FindAsync(id);
            if (instCarryCap == null)
            {
                return NotFound();
            }

            _context.InstCarryCap.Remove(instCarryCap);
            await _context.SaveChangesAsync();

            return instCarryCap;
        }

        private bool InstCarryCapExists(int id)
        {
            return _context.InstCarryCap.Any(e => e.Id == id);
        }
    }
}
