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
    public class InstitutionOfficersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstitutionOfficersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InstitutionOfficers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitutionOfficer>>> GetInstitutionOfficers()
        {
            return await _context.InstitutionOfficers.ToListAsync();
        }

        // GET: api/InstitutionOfficers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstitutionOfficer>> GetInstitutionOfficer(int? id)
        {
            if (id == null)
            {
                return BadRequest("Officer ID is Empty");
            }
            try
            {
                var institutionOfficer = await _context.InstitutionOfficers.Include(x => x.Institution)
                    .Where(x => x.Institution.Id == x.InstitutionId && x.Id == id  && x.Deactivate == false).SingleOrDefaultAsync();

                if (institutionOfficer == null)
                {
                    return NotFound($"Officer Not Found For The Selected Id {id}");
                }
                return Ok(institutionOfficer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/InstitutionOfficers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutionOfficer(int id, InstitutionOfficer institutionOfficer)
        {
            if (id != institutionOfficer.Id)
            {
                return BadRequest();
            }

            _context.Entry(institutionOfficer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionOfficerExists(id))
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

        // POST: api/InstitutionOfficers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InstitutionOfficer>> PostInstitutionOfficer(InstitutionOfficer institutionOfficer)
        {
            try
            {
                var newOfficer= new InstitutionOfficer
                {
                    InstitutionId = institutionOfficer.InstitutionId,
                    OfficerType = institutionOfficer.OfficerType,
                    IntOfficerName = institutionOfficer.IntOfficerName,
                    Address1 = institutionOfficer.Address1,
                    IntOfficerDesig = institutionOfficer.IntOfficerDesig,
                    PhoneNo = institutionOfficer.PhoneNo,
                    Email = institutionOfficer.Email,
                    //Change the stateID to LGA
                    StaffId = institutionOfficer.StaffId, 
                    AccountName = institutionOfficer.AccountName,
                    //BankName = institutionOfficer.BankName,
                    AccountNo = institutionOfficer.AccountNo,
                    SwitchCode=institutionOfficer.SwitchCode,
                    NumberOfStudent = institutionOfficer.NumberOfStudent,
                };
                _context.InstitutionOfficers.Add(newOfficer);
                await _context.SaveChangesAsync();


                return CreatedAtAction("PostInstitutionOfficer", new { id = newOfficer.Id }, newOfficer);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Menu Name Already Exist");
            }
        }

        // DELETE: api/InstitutionOfficers/5
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
