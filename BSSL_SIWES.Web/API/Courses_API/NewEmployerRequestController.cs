using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web.API.Courses_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewEmployerRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewEmployerRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NewEmployerRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewCourseRequest>>> GetNewCourseRequests()
        {
            return await _context.NewCourseRequests.ToListAsync();
        }

        // GET: api/NewEmployerRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewCourseRequest>> GetNewCourseRequest(int id)
        {
            var employerSuperSetup = await _context.NewCourseRequests.Include(x => x.AreaOffice)
                .Include(x => x.LGA).Include(x => x.BusinessLine)
                .Where(x => x.AreaOffice.Id == x.AreaOfficeId && x.BusinessLine.Id == x.BusinessLineId && x.LGAId == x.LGA.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employerSuperSetup == null)
            {
                return NotFound();
            }

            return employerSuperSetup;
        }

        // PUT: api/NewEmployerRequest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewCourseRequest(int id, NewCourseRequest newCourseRequest)
        {
            if (id != newCourseRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(newCourseRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewCourseRequestExists(id))
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

        // POST: api/NewEmployerRequest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NewCourseRequest>> PostNewCourseRequest(NewCourseRequest newCourseRequest)
        {
            try
            {

                var newCourseRecom = new NewCourseRequest
                {
                    Name = newCourseRequest.Name,
                    Approved = newCourseRequest.Approved = false,
                    DateIn = newCourseRequest.DateIn = DateTime.Now,
                    InstitiutionId = newCourseRequest.InstitiutionId,
                    ReqstType = newCourseRequest.ReqstType,
                    Code = newCourseRequest.Code,

                    Address1 = newCourseRequest.Address1,
                    Address2 = newCourseRequest.Address2,
                    LGAId = newCourseRequest.LGAId,
                    CoporationType = newCourseRequest.CoporationType,
                    YearOfIncop = newCourseRequest.YearOfIncop,
                    BusinessLineId = newCourseRequest.BusinessLineId,

                    BusinessType = newCourseRequest.BusinessType,
                    AreaOfficeId = newCourseRequest.AreaOfficeId,
                    WebAddress = newCourseRequest.WebAddress,
                    Email = newCourseRequest.Email,
                    PhoneNo = newCourseRequest.PhoneNo,
                    PhoneNo2 = newCourseRequest.PhoneNo2,
                };
                _context.NewCourseRequests.Add(newCourseRecom);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostNewCourseRequest", new { id = newCourseRecom.Id }, newCourseRecom);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, $"{newCourseRequest.Name} HAS BEEN SENT FOR SETUP, PREVIOUSLY, PLEASE CHECK!!!");
            }
        }

        // DELETE: api/NewEmployerRequest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewCourseRequest>> DeleteNewCourseRequest(int id)
        {
            var newCourseRequest = await _context.NewCourseRequests.FindAsync(id);
            if (newCourseRequest == null)
            {
                return NotFound();
            }

            _context.NewCourseRequests.Remove(newCourseRequest);
            await _context.SaveChangesAsync();

            return newCourseRequest;
        }

        private bool NewCourseRequestExists(int id)
        {
            return _context.NewCourseRequests.Any(e => e.Id == id);
        }
    }
}
