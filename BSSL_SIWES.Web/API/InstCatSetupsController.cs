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
    public class InstCatSetupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstCatSetupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InstCatSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstCatSetup>>> GetInstCatSetup()
        {
            return await _context.InstCatSetup.ToListAsync();
        }

        // GET: api/InstCatSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstCatSetup>> GetInstCatSetup(int id)
        {
            var instCatSetup = await _context.InstCatSetup.FindAsync(id);


            if (instCatSetup == null)
            {
                return NotFound();
            }

            return instCatSetup;
        }

        // PUT: api/InstCatSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstCatSetup(int id, InstCatSetup instCatSetup)
        {
            if (id != instCatSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(instCatSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstCatSetupExists(id))
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

        // POST: api/InstCatSetups
        [HttpPost]
        public async Task<ActionResult<InstCatSetup>> PostInstCatSetup(InstCatSetup instCatSetup)
        {
            _context.InstCatSetup.Add(instCatSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstCatSetup", new { id = instCatSetup.Id }, instCatSetup);
        }

        // DELETE: api/InstCatSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstCatSetup>> DeleteInstCatSetup(int id)
        {
            var instCatSetup = await _context.InstCatSetup.FindAsync(id);
            if (instCatSetup == null)
            {
                return NotFound();
            }

            _context.InstCatSetup.Remove(instCatSetup);
            await _context.SaveChangesAsync();

            return instCatSetup;
        }

        private bool InstCatSetupExists(int id)
        {
            return _context.InstCatSetup.Any(e => e.Id == id);
        }
    }
}
