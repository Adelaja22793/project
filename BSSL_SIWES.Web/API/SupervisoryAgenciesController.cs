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
    public class SupervisoryAgenciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SupervisoryAgenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SupervisoryAgencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupervisoryAgency>>> GetSupervisoryAgencies()
        {
            return await _context.SupervisoryAgencies.ToListAsync();
        }

        // GET: api/SupervisoryAgencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupervisoryAgency>> GetSupervisoryAgency(int id)
        {
            var supervisoryAgency = await _context.SupervisoryAgencies.FindAsync(id);

            if (supervisoryAgency == null)
            {
                return NotFound();
            }

            return supervisoryAgency;
        }

        // PUT: api/SupervisoryAgencies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupervisoryAgency(int id, SupervisoryAgency supervisoryAgency)
        {
            if (id != supervisoryAgency.Id)
            {
                return BadRequest();
            }

            _context.Entry(supervisoryAgency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisoryAgencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(supervisoryAgency);
        }

        // POST: api/SupervisoryAgencies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SupervisoryAgency>> PostSupervisoryAgency(SupervisoryAgency supervisoryAgency)
        {
            _context.SupervisoryAgencies.Add(supervisoryAgency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupervisoryAgency", new { id = supervisoryAgency.Id }, supervisoryAgency);
        }

        // DELETE: api/SupervisoryAgencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupervisoryAgency>> DeleteSupervisoryAgency(int id)
        {
            var supervisoryAgency = await _context.SupervisoryAgencies.FindAsync(id);
            if (supervisoryAgency == null)
            {
                return NotFound();
            }

            _context.SupervisoryAgencies.Remove(supervisoryAgency);
            await _context.SaveChangesAsync();

            return supervisoryAgency;
        }

        private bool SupervisoryAgencyExists(int id)
        {
            return _context.SupervisoryAgencies.Any(e => e.Id == id);
        }
    }
}
