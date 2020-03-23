using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using SiwesData.Data;
using SiwesData.Menu;

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        public class MenuViewModel
        {
            public string MenuName { get; set; }
        }
        private readonly SiwesData.ApplicationDbContext _context;
        public MenusController(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        public string Message { get; set; }
        // GET: api/Menus
        [HttpGet]
        public List<Menu> GetMenu()
        {
            var MenuList = _context.Menu.ToList();

            return MenuList;
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int? id)
        {
            if (id == null)
            {
                return BadRequest("MenuId is Empty");
            }
            try
            {
                var menu = await _context.Menu.FindAsync(id);

                if (menu == null)
                {
                    return NotFound($"Menu Not Found For The Selected Id {id}");
                }
                return Ok(menu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int? id, MenuViewModel menuVM)
        {
            if (id == null)
            {
                return BadRequest("MenuId is Empty");
            }

            try
            {
                var updateMenu = await _context.Menu.FirstOrDefaultAsync(m => m.Id == id);

                if (updateMenu == null)
                {
                    return NotFound($"Menu Not Found For The Selected Id {id}");
                }
                updateMenu.Name = menuVM.MenuName;
                await _context.SaveChangesAsync();
                return Ok(updateMenu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Menus
        //[Route("Menus")]
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(MenuViewModel menuVm)
        {
            try
            {
                var newMenu = new Menu { Name = menuVm.MenuName };
                _context.Menu.Add(newMenu);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostMenu", new { id = newMenu.Id }, newMenu);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Menu Name Already Exist");
            }

           
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Menu>> DeleteMenu(int? id, MenuViewModel menuVM)
        {
            
            if (id == null)
            {
                return BadRequest("MenuId is Empty");
            }

            try
            {
                var menu = await _context.Menu.FindAsync(id);
                if (menu == null)
                {
                    return NotFound($"Menu Not Found For The Selected Id {id}");
                }
                _context.Menu.Remove(menu);
                await _context.SaveChangesAsync();
                menu.Name = menuVM.MenuName;
                //return DeleteMenu(id, menu.Name);
                return Ok(menu);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
           
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.Id == id);
        }
    }
}
