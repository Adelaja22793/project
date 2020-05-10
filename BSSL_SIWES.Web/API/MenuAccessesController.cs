using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Menu;

namespace SIWES_BSSL.API
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
        [HttpGet("{roleid}")]

        public ActionResult<IEnumerable<MenuAccess>> GetMenuAcces()
        {
            foreach (var person in _context.MenuAccess)
            {
                var menuacces = new MenuAccess()
                {
                    SubMenuId = person.SubMenuId
                };
                _context.MenuAccess.Add(menuacces);
            }
            return StatusCode(500);
            //MenuAccess menuaccess = new MenuAccess();
            //using (ApplicationDbContext _context = new ApplicationDbContext())
            //{
            //    menuaccess.SubMenuId = _context.Menu
            //}

            //    List<MenuAccess> entities = new List<MenuAccess>();
            //entities = (from e in _context.MenuAccess
            //                               where e.RoleId == roleId
            //                               select new MenuAccess
            //                               {
            //                                   //Id = e.EmployeeID,
            //                                   SubMenuId = e.SubMenuId,
            //                                   //LastName = e.LastName,
            //                                   //City = e.City,
            //                                   //Country = e.Country
            //                               }).ToList();
            //return StatusCode(500);

        }

        // PUT: api/MenuAccesses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{roleid}")]
        public async Task<IActionResult> PutMenuAccess(string roleid, MenuAccess menuAccess)
        {
            if (roleid != menuAccess.RoleId)
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
                if (!MenuAccessExists(roleid))
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
        public async Task<ActionResult<MenuAccess>> PostMenuAccess(string RoleId, MenuAccess menuAccess)
        {
            if (!_context.MenuAccess.Any(e => e.RoleId == menuAccess.RoleId))
            {
                _context.MenuAccess.Add(menuAccess);

            }

            else
            {


                var pos = await _context.MenuAccess.FirstOrDefaultAsync(e => e.RoleId == menuAccess.RoleId);
                if (pos != null)
                {
                    pos.RoleId = menuAccess.RoleId;
                    pos.SubMenuId = menuAccess.SubMenuId;
                }



                //return Ok(menuAccess);
            }
            await _context.SaveChangesAsync();
            return Ok(menuAccess);
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //_context.Attach(Movie).State = EntityState.Modified;
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!MovieExists(Movie.ID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtAction("PostMenuAccess", new { id = menuAccess.RoleId }, menuAccess);
            //try
            //{
            //    var newMonthlyAssessment = new MenuAccess
            //    {
            //        RoleId = menuAccess.RoleId,
            //        SubMenuId = menuAccess.SubMenuId,
            //    };
            //    _context.MenuAccess.Add(newMonthlyAssessment);
            //    await _context.SaveChangesAsync();

            //    return CreatedAtAction("PostMenuAccess", new { id = newMonthlyAssessment.Id }, newMonthlyAssessment);
            //}
            //catch (DbUpdateException)
            //{

            //}
            //return StatusCode(500);
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

        private bool MenuAccessExists(string roleid)
        {
            return _context.MenuAccess.Any(e => e.RoleId == roleid);
        }
    }
}
