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
    public class DailyActivitiesController : ControllerBase
    {
        public class DailyActivitiesViewModels
        {
            public int stdId { get; set; }
            public string WeekNumber { get; set; }
            public bool Approved { get; set; }
            public DateTime CerifiedDate { get; set; }
            public int EmployerSupervisorId { get; set; }
        }
        
        private readonly ApplicationDbContext _context;

        public DailyActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyActivities>>> GetDailyActivities()
        {
            return await _context.DailyActivities.ToListAsync();
        }

        // GET: api/DailyActivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyActivities>> GetDailyActivities(int? id)
        {
            if (id == null)
            {
                return BadRequest("Daily Activities is Empty");
            }
            try
            {
                var dailyActivities = await _context.DailyActivitiesLists.Include(v => v.DailyActivities)
                    .SingleOrDefaultAsync(x => x.DailyActivitiesId == x.DailyActivities.Id);
                    //.FindAsync(id);

                if (dailyActivities == null)
                {
                    return NotFound($"Daily/Weekly Activities Not Found For The Selected Id {id}");
                }
                return Ok(dailyActivities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
                
        }

        // PUT: api/DailyActivities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyActivities(int id, DailyActivities dailyActivities)
        {
            if (id != dailyActivities.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyActivities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyActivitiesExists(id))
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

        // POST: api/DailyActivities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DailyActivities>> PostDailyActivities(DailyActivities dailyActivitiesList)
        {
            try
            {
                var dailyActivities = new DailyActivities {
                    StudentSetUpId = dailyActivitiesList.StudentSetUpId,
                    WeekNumber = dailyActivitiesList.WeekNumber,
                    Approved = dailyActivitiesList.Approved = false,
                };
                _context.DailyActivities.Add(dailyActivities);
                await _context.SaveChangesAsync();


                return CreatedAtAction("PostDailyActivities", new { id = dailyActivities.Id }, dailyActivities);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Menu Name Already Exist");
            }
        }

        // DELETE: api/DailyActivities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyActivities>> DeleteDailyActivities(int id)
        {
            var dailyActivities = await _context.DailyActivities.FindAsync(id);
            if (dailyActivities == null)
            {
                return NotFound();
            }

            _context.DailyActivities.Remove(dailyActivities);
            await _context.SaveChangesAsync();

            return dailyActivities;
        }

        private bool DailyActivitiesExists(int id)
        {
            return _context.DailyActivities.Any(e => e.Id == id);
        }
    }
}
