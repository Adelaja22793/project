﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using SIWES_BSSL.Data;
using SIWES_BSSL.Data.Menu;

namespace SIWES_BSSL.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;
        public MenusController(SIWES_BSSL.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string Message { get; set; }
        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenu()
        {
            return await _context.Menu.ToListAsync();
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menu.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }

            var updatedAddress = await _context.Menu.FirstOrDefaultAsync(m => m.Id == id);

            updatedAddress.Name = menu.Name;
            var nameExit = await _context.Menu.FirstOrDefaultAsync(m => m.Name == menu.Name);
         
                try
                {
                    // _context.Update(address);
                    await _context.SaveChangesAsync();
                    return Ok(updatedAddress);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(id))
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

        // POST: api/Menus
        //[Route("Menus")]
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Menu>> DeleteMenu(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();

            return menu;
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.Id == id);
        }
    }
}
