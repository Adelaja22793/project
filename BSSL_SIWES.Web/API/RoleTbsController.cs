using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using Microsoft.AspNetCore.Identity;
using SiwesData.Setup;


namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTbsController : ControllerBase
    {
        private readonly  ApplicationDbContext _context;
        private readonly RoleManager<RoleTb> _roleManager;

        public RoleTbsController(ApplicationDbContext context, RoleManager<RoleTb> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
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
            if (!_context.RoleTb.Any(e => e.Id == roleTb.Id))
            {
                //_context.RoleTb.Add(roleTb);
                await _context.SaveChangesAsync();
            }
            else
            {
                var pos = await _context.RoleTb.FirstOrDefaultAsync(x => x.Id == roleTb.Id);
                pos.Id = roleTb.Id;
                pos.Name = roleTb.Name;

                await _context.SaveChangesAsync();
            }
            return Ok(roleTb);
        }
       

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
                //_context.RoleTb.Add(roleTb);
                //await _context.SaveChangesAsync();

              //  bool x = await _roleManager.RoleExistsAsync("Employer");
                //if (!x)
                //{
                    var role = new RoleTb();
                    role.Name = roleTb.Name;
                    role.RoleId =roleTb.RoleId;
                    await _roleManager.CreateAsync(role);
               // }
            }
            else
            {
                return Conflict("RoleId Already Exists");
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
