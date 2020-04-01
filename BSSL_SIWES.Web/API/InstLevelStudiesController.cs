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
    public class InstLevelStudiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstLevelStudiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InstLevelStudies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstLevelStudy>>> GetInstLevelStudy()
        {
            return await _context.InstLevelStudy.ToListAsync();
        }

        // GET: api/InstLevelStudies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstLevelStudy>> GetInstLevelStudy(int id)
        {
            var instLevelStudy = await _context.InstLevelStudy.FindAsync(id);

            if (instLevelStudy == null)
            {
                return NotFound();
            }

            return instLevelStudy;
        }

        // PUT: api/InstLevelStudies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstLevelStudy(int id, InstLevelStudy instLevelStudy)
        {
            if (id != instLevelStudy.Id)
            {
                return BadRequest();
            }

            _context.Entry(instLevelStudy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstLevelStudyExists(id))
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

        // POST: api/InstLevelStudies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InstLevelStudy>> PostInstLevelStudy(InstLevelStudy instLevelStudy)
        {
            _context.InstLevelStudy.Add(instLevelStudy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstLevelStudy", new { id = instLevelStudy.Id }, instLevelStudy);
        }

        // DELETE: api/InstLevelStudies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstLevelStudy>> DeleteInstLevelStudy(int id)
        {
            var instLevelStudy = await _context.InstLevelStudy.FindAsync(id);
            if (instLevelStudy == null)
            {
                return NotFound();
            }

            _context.InstLevelStudy.Remove(instLevelStudy);
            await _context.SaveChangesAsync();

            return instLevelStudy;
        }

        private bool InstLevelStudyExists(int id)
        {
            return _context.InstLevelStudy.Any(e => e.Id == id);
        }
    }
}
