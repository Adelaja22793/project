using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData.Data;
using SiwesData.Data.Setup;

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstTypeSetupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstTypeSetupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InstTypeSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstTypeSetup>>> GetInstTypeSetup()
        {
            return await _context.InstTypeSetup.ToListAsync();
        }

        // GET: api/InstTypeSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstTypeSetup>> GetInstTypeSetup(int id)
        {
            var instTypeSetup = await _context.InstTypeSetup.FindAsync(id);

            if (instTypeSetup == null)
            {
                return NotFound();
            }

            return instTypeSetup;
        }

        // PUT: api/InstTypeSetups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstTypeSetup(int id, InstTypeSetup instTypeSetup)
        {
            if (id != instTypeSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(instTypeSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstTypeSetupExists(id))
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

        // POST: api/InstTypeSetups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InstTypeSetup>> PostInstTypeSetup(InstTypeSetup instTypeSetup)
        {
            _context.InstTypeSetup.Add(instTypeSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstTypeSetup", new { id = instTypeSetup.Id }, instTypeSetup);
        }

        // DELETE: api/InstTypeSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstTypeSetup>> DeleteInstTypeSetup(int id)
        {
            var instTypeSetup = await _context.InstTypeSetup.FindAsync(id);
            if (instTypeSetup == null)
            {
                return NotFound();
            }

            _context.InstTypeSetup.Remove(instTypeSetup);
            await _context.SaveChangesAsync();

            return instTypeSetup;
        }

        private bool InstTypeSetupExists(int id)
        {
            return _context.InstTypeSetup.Any(e => e.Id == id);
        }
    }
}
