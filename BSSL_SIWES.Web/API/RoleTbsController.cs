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
    public class RoleTbsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoleTbsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RoleTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleTb>>> GetRoleTb()
        {
            return await _context.RoleTb.ToListAsync();
        }

        // GET: api/RoleTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleTb>> GetRoleTb(string id)
        {
            var roleTb = await _context.RoleTb.FindAsync(id);

            if (roleTb == null)
            {
                return NotFound();
            }

            return roleTb;
        }

        // PUT: api/RoleTbs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleTb(string id, RoleTb roleTb)
        {
            //var studentToUpdate = await _context.Students.FindAsync(id);
            //if (studentToUpdate == null)
            //{
            //    return NotFound();
            //}
            //if (await TryUpdateModelAsync<Student>(
            //studentToUpdate,
            //"student",
            //s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            //{
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(roleTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RoleTb.Any(e => e.RoleId == roleTb.RoleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
                return Ok(roleTb);
        }

            //return Ok(roleTb);
        

        // POST: api/RoleTbs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RoleTb>> PostRoleTb(RoleTb roleTb)
        {
            var nameCheck = _context.RoleTb
                        .Where(b => b.RoleId == roleTb.RoleId)
                        .FirstOrDefault();
            if (nameCheck == null)
            {
                // save the item here
                _context.RoleTb.Add(roleTb);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Conflict("The item already exists");
            }

            return CreatedAtAction("GetRoleTb", new { id = roleTb.RoleId }, roleTb);
        }

        // DELETE: api/RoleTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleTb>> DeleteRoleTb(string id)
        {
            var roleTb = await _context.RoleTb.FindAsync(id);
            if (roleTb == null)
            {
                return NotFound();
            }

            _context.RoleTb.Remove(roleTb);
            await _context.SaveChangesAsync();

            return roleTb;
        }

        private bool RoleTbExists(string id)
        {
            return _context.RoleTb.Any(e => e.Id == id);
        }
    }
}
