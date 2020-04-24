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
    public class InstOfficerDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstOfficerDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InstOfficerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitutionOfficer>>> GetInstitutionOfficers()
        {
            return await _context.InstitutionOfficers.ToListAsync();
        }

        // GET: api/InstOfficerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstitutionOfficer>> GetInstitutionOfficer(int id)
        {
            var instOfficerDetails = await _context.InstitutionOfficers.Include(x => x.Institution)
                .Include(x => x.LGA).Include(x => x.BankSetUp)
                .Where(x => x.Institution.Id == x.InstitutionId && x.BankSetUp.Id == x.BankSetUpId && x.LGAId == x.LGA.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (instOfficerDetails == null)
            {
                return NotFound();
            }

            return instOfficerDetails;
        }

        // PUT: api/InstOfficerDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutionOfficer(int? id, InstitutionOfficer institutionOfficer)
        {
            if (id == null)
            {
                return BadRequest("Intitution Officer is Empty");
            }

            try
            {
                var updateOfficerRecord = await _context.InstitutionOfficers.FirstOrDefaultAsync(m => m.Id == id);

                if (updateOfficerRecord == null)
                {
                    return NotFound($"Officer Not Found For The Selected Id {id}");
                }
                updateOfficerRecord.Deactivate = institutionOfficer.Deactivate = true;
                updateOfficerRecord.DateActivated = institutionOfficer.DateActivated;
                updateOfficerRecord.ReasonDeactivate = institutionOfficer.ReasonDeactivate;

                await _context.SaveChangesAsync();

                return Ok(updateOfficerRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/InstOfficerDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InstitutionOfficer>> PostInstitutionOfficer(InstitutionOfficer institutionOfficer)
        {
            _context.InstitutionOfficers.Add(institutionOfficer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitutionOfficer", new { id = institutionOfficer.Id }, institutionOfficer);
        }

        // DELETE: api/InstOfficerDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstitutionOfficer>> DeleteInstitutionOfficer(int id)
        {
            var institutionOfficer = await _context.InstitutionOfficers.FindAsync(id);
            if (institutionOfficer == null)
            {
                return NotFound();
            }

            _context.InstitutionOfficers.Remove(institutionOfficer);
            await _context.SaveChangesAsync();

            return institutionOfficer;
        }

        private bool InstitutionOfficerExists(int id)
        {
            return _context.InstitutionOfficers.Any(e => e.Id == id);
        }
    }
}
