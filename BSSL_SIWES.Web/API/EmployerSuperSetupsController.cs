using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Employer;

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerSuperSetupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployerSuperSetupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployerSuperSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployerSuperSetup>>> GetEmployerSuperSetups()
        {
            return await _context.EmployerSuperSetups.ToListAsync();
            //return await _context.EmployerSuperSetups.Include(x => x.AreaOffice)
            //    .Where(x => x.AreaOffice.Id == x.AreaOfficeId).FirstOrDefaultAsync(x => x.Id == id);
        }

        // GET: api/EmployerSuperSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerSuperSetup>> GetEmployerSuperSetup(int id)
        {
            var employerSuperSetup = await _context.EmployerSuperSetups.Include(x =>x.AreaOffice)
                .Include(x => x.LGA).Include(x => x.BusinessLine)
                .Where(x => x.AreaOffice.Id == x.AreaOfficeId && x.BusinessLine.Id == x.BusinessLineId && x.LGAId == x.LGA.Id)
                .FirstOrDefaultAsync(x =>x.Id == id);

            if (employerSuperSetup == null)
            {
                return NotFound();
            }

            return employerSuperSetup;
        }

        // PUT: api/EmployerSuperSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployerSuperSetup(int? id, EmployerSuperSetup employerSuperSetup)
        {
            if (id == null)
            {
                return BadRequest("Employer is Empty");
            }

            try
            {
                var updateEmployerRecord = await _context.EmployerSuperSetups.FirstOrDefaultAsync(m => m.Id == id);

                if (updateEmployerRecord == null)
                {
                    return NotFound($"Employer Not Found For The Selected Id {id}");
                }
                updateEmployerRecord.Name = employerSuperSetup.Name;
                updateEmployerRecord.Code = employerSuperSetup.Code;

                updateEmployerRecord.Address1 = employerSuperSetup.Address1;
                updateEmployerRecord.Address2 = employerSuperSetup.Address2;
                updateEmployerRecord.LGAId = employerSuperSetup.LGAId;
                updateEmployerRecord.CoporationType = employerSuperSetup.CoporationType;
                updateEmployerRecord.YearOfIncop = employerSuperSetup.YearOfIncop;
                updateEmployerRecord.BusinessLineId = employerSuperSetup.BusinessLineId;

                updateEmployerRecord.BusinessType = employerSuperSetup.BusinessType;
                updateEmployerRecord.AreaOfficeId = employerSuperSetup.AreaOfficeId;
                updateEmployerRecord.WebAddress = employerSuperSetup.WebAddress;
                updateEmployerRecord.Email = employerSuperSetup.Email;
                updateEmployerRecord.PhoneNo = employerSuperSetup.PhoneNo;
                updateEmployerRecord.PhoneNo2 = employerSuperSetup.PhoneNo2;
                await _context.SaveChangesAsync();
                return Ok(updateEmployerRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/EmployerSuperSetups
        [HttpPost]
        public async Task<ActionResult<EmployerSuperSetup>> PostEmployerSuperSetup(EmployerSuperSetup employerSuperSetup)
        {
            try
            {

                var newCourseRecom = new EmployerSuperSetup
                {
                    Name = employerSuperSetup.Name,
                    Code = employerSuperSetup.Code,

                    Address1 = employerSuperSetup.Address1,
                    Address2 = employerSuperSetup.Address2,
                    LGAId = employerSuperSetup.LGAId,
                    CoporationType = employerSuperSetup.CoporationType,
                    YearOfIncop = employerSuperSetup.YearOfIncop,
                    BusinessLineId = employerSuperSetup.BusinessLineId,

                    BusinessType = employerSuperSetup.BusinessType,
                    AreaOfficeId = employerSuperSetup.AreaOfficeId,
                    WebAddress = employerSuperSetup.WebAddress,
                    Email = employerSuperSetup.Email,
                    PhoneNo = employerSuperSetup.PhoneNo,
                    PhoneNo2 = employerSuperSetup.PhoneNo2,
                };
                _context.EmployerSuperSetups.Add(newCourseRecom);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostemployerSuperSetup", new { id = newCourseRecom.Id }, newCourseRecom);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, $"{employerSuperSetup.Name} HAS BEEN SENT FOR SETUP, PREVIOUSLY, PLEASE CHECK!!!");
            }
        }

        // DELETE: api/EmployerSuperSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployerSuperSetup>> DeleteEmployerSuperSetup(int id)
        {
            var employerSuperSetup = await _context.EmployerSuperSetups.FindAsync(id);
            if (employerSuperSetup == null)
            {
                return NotFound();
            }

            _context.EmployerSuperSetups.Remove(employerSuperSetup);
            await _context.SaveChangesAsync();

            return employerSuperSetup;
        }

        private bool EmployerSuperSetupExists(int id)
        {
            return _context.EmployerSuperSetups.Any(e => e.Id == id);
        }
    }
}
