using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData.Data;
using SiwesData.Data.Setup;

namespace BSSL_SIWES.Web.API.Nationality
{
    [Route("api/[controller]")]
    [ApiController]
    public class LGAsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LGAsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LGAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LGA>>> GetLGAs()
        {
            return await _context.LGAs.ToListAsync();
        }

        // GET: api/LGAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LGA>>> GetLGA(int id)
        {
            //var lGA = await _context.LGAs.FindAsync(id);
            var lGAs = await _context.LGAs.Where(c => c.StateId == id).ToListAsync();

            if (lGAs == null)
            {
                return NotFound();
            }
            //this is an anonymousa type
            var a = lGAs.Select(x => new { id = x.Id, name = x.Name });
            return Ok(a);
        }

        // PUT: api/LGAs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLGA(int id, LGA lGA)
        {
            if (id != lGA.Id)
            {
                return BadRequest();
            }

            _context.Entry(lGA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LGAExists(id))
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

        // POST: api/LGAs
        [HttpPost]
        public async Task<ActionResult<LGA>> PostLGA(LGA lGA)
        {
            _context.LGAs.Add(lGA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLGA", new { id = lGA.Id }, lGA);
        }

        // DELETE: api/LGAs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LGA>> DeleteLGA(int id)
        {
            var lGA = await _context.LGAs.FindAsync(id);
            if (lGA == null)
            {
                return NotFound();
            }

            _context.LGAs.Remove(lGA);
            await _context.SaveChangesAsync();

            return lGA;
        }

        private bool LGAExists(int id)
        {
            return _context.LGAs.Any(e => e.Id == id);
        }
    }
}
