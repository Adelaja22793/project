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
    public class PolicyTbsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PolicyTbsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PolicyTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyTb>>> GetPolicyTb()
        {
            return await _context.PolicyTb.ToListAsync();
        }

        // GET: api/PolicyTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyTb>> GetPolicyTb(int id)
        {
            var policyTb = await _context.PolicyTb.FindAsync(id);

            if (policyTb == null)
            {
                return NotFound();
            }

            return policyTb;
        }

        // PUT: api/PolicyTbs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyTb(int id, PolicyTb policyTb)
        {
            if (id != policyTb.Id)
            {
                return BadRequest();
            }

            _context.Entry(policyTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyTbExists(id))
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

        // POST: api/PolicyTbs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PolicyTb>> PostPolicyTb(PolicyTb policyTb)
        {
            _context.PolicyTb.Add(policyTb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyTb", new { id = policyTb.Id }, policyTb);
        }

        // DELETE: api/PolicyTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PolicyTb>> DeletePolicyTb(int id)
        {
            var policyTb = await _context.PolicyTb.FindAsync(id);
            if (policyTb == null)
            {
                return NotFound();
            }

            _context.PolicyTb.Remove(policyTb);
            await _context.SaveChangesAsync();

            return policyTb;
        }

        private bool PolicyTbExists(int id)
        {
            return _context.PolicyTb.Any(e => e.Id == id);
        }
    }
}
