using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Students;

namespace BSSL_SIWES.Web.API.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorVisitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SupervisorVisitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SupervisorVisits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupervisorVisit>>> GetSupervisorVisits()
        {
            return await _context.SupervisorVisits.ToListAsync();
        }

        // GET: api/SupervisorVisits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SupervisorVisit>>> GetSupervisorVisit(int id)
        {
            var supervisorVisit = await _context.SupervisorVisits.Where(x =>x.StudentSetUpId == id).ToListAsync();
          

            if (supervisorVisit == null)
            {
                return NotFound();
            }

            return supervisorVisit;
        }

        // PUT: api/SupervisorVisits/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupervisorVisit(int id, SupervisorVisit supervisorVisit)
        {
            if (id != supervisorVisit.Id)
            {
                return BadRequest();
            }

            _context.Entry(supervisorVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisorVisitExists(id))
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

        // POST: api/SupervisorVisits
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SupervisorVisit>> PostSupervisorVisit(SupervisorVisit supervisorVisit)
        {
            try
            {
                var superVisit = new SupervisorVisit
                {
                    StudentSetUpId = supervisorVisit.StudentSetUpId,
                    DateVisited = supervisorVisit.DateVisited,
                    AreaToImprove = supervisorVisit.AreaToImprove,
                    StudentInvolvement = supervisorVisit.StudentInvolvement,
                };
                _context.SupervisorVisits.Add(superVisit);
                await _context.SaveChangesAsync();


                return CreatedAtAction("PostSupervisorVisit", new { id = superVisit.Id }, superVisit);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/SupervisorVisits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupervisorVisit>> DeleteSupervisorVisit(int id)
        {
            var supervisorVisit = await _context.SupervisorVisits.FindAsync(id);
            if (supervisorVisit == null)
            {
                return NotFound();
            }

            _context.SupervisorVisits.Remove(supervisorVisit);
            await _context.SaveChangesAsync();

            return supervisorVisit;
        }

        private bool SupervisorVisitExists(int id)
        {
            return _context.SupervisorVisits.Any(e => e.Id == id);
        }
    }
}
