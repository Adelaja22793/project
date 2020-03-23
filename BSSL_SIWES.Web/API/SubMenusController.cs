using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData.Data.Menu;


namespace SIWES_BSSL.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenusController : ControllerBase
    {
        private readonly SiwesData.Data.ApplicationDbContext _context;

        public SubMenusController(SiwesData.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubMenu SubMenu { get; set; }
        // GET: api/SubMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubMenu>>> GetSubMenu()
        {
            return await _context.SubMenu.ToListAsync();
        }

        // GET: api/SubMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubMenu>> GetSubMenu(int id)
        {
            var subMenu = await _context.SubMenu.FindAsync(id);

            if (subMenu == null)
            {
                return NotFound();
            }

            return subMenu;
        }

        // PUT: api/SubMenus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubMenu(int id, SubMenu subMenu)
        {
            if (id != subMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(subMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubMenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(subMenu);
        }

        // POST: api/SubMenus
        [HttpPost]
        public async Task<ActionResult<SubMenu>> PostSubMenu(SubMenu subMenu)
        {
            _context.SubMenu.Add(subMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubMenu", new { id = subMenu.Id }, subMenu);
        }

        // DELETE: api/SubMenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubMenu>> DeleteSubMenu(int id)
        {
            var subMenu = await _context.SubMenu.FindAsync(id);
            if (subMenu == null)
            {
                return NotFound();
            }

            _context.SubMenu.Remove(subMenu);
            await _context.SaveChangesAsync();

            return subMenu;
        }

        private bool SubMenuExists(int id)
        {
            return _context.SubMenu.Any(e => e.Id == id);
        }
    }
}

