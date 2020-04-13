using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Menu;

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuAccessesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MenuAccessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuAccesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuAccess>>> GetMenuAccess()
        {
            return await _context.MenuAccess.ToListAsync();
        }

        // GET: api/MenuAccesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuAccess>> GetMenuAccess(int id)
        {
            var menuAccess = await _context.MenuAccess.FindAsync(id);

            if (menuAccess == null)
            {
                return NotFound();
            }

            return menuAccess;
        }

        // PUT: api/MenuAccesses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuAccess(int id, MenuAccess menuAccess)
        {
            if (id != menuAccess.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuAccessExists(id))
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

        // POST: api/MenuAccesses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MenuAccess>> PostMenuAccess(MenuAccess menuAccess)
        {
            try
            {
                var newMonthlyAssessment = new MenuAccess
                {
                    RoleId = menuAccess.RoleId,
                    SubMenuId = menuAccess.SubMenuId,
                };
                _context.MenuAccess.Add(newMonthlyAssessment);
                await _context.SaveChangesAsync();


                return CreatedAtAction("PostMenuAccess", new { id = newMonthlyAssessment.Id }, newMonthlyAssessment);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500);
            }
        }
        
        // DELETE: api/MenuAccesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuAccess>> DeleteMenuAccess(int id)
        {
            var menuAccess = await _context.MenuAccess.FindAsync(id);
            if (menuAccess == null)
            {
                return NotFound();
            }

            _context.MenuAccess.Remove(menuAccess);
            await _context.SaveChangesAsync();

            return menuAccess;
        }

        private bool MenuAccessExists(int id)
        {
            return _context.MenuAccess.Any(e => e.Id == id);
        }
    }
}
