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
    public class DailyActivitiesListsController : ControllerBase
    {
        public class DayList
        {
            public int DailyActivitiesId { get; set; }
            public DateTime Day { get; set; }
            public string DayDescription { get; set; }
            public int DayValue { get; set; }
        }
        private readonly ApplicationDbContext _context;

        public DailyActivitiesListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyActivitiesLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyActivitiesList>>> GetDailyActivitiesLists()
        {
            return await _context.DailyActivitiesLists.ToListAsync();
        }

        // GET: api/DailyActivitiesLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyActivitiesList>> GetDailyActivitiesList(int? id)
        {
            if (id == null)
            {
                return BadRequest("No Daily Activities For This Student");
            }
            try
            {
              var  DailyActivitiesLists = await _context.DailyActivitiesLists.Include(b => b.DailyActivities)
                           .Where(x =>x.DailyActivities.Id == id)
                           .ToListAsync();
                if (DailyActivitiesLists == null)
                {
                    return NotFound($"Daily/Weekly Activities Not Found For The Selected Id {id}");
                }
                return Ok(DailyActivitiesLists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/DailyActivitiesLists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyActivitiesList(int? id, DailyActivitiesList dailyActivitiesList)
        {
            if (id == null)
            {
                return BadRequest("No Activity Found");
            }

            try
            {
                var updateDailyActivities = await _context.DailyActivitiesLists.FirstOrDefaultAsync(m => m.Id == id);

                if (updateDailyActivities == null)
                {
                    return NotFound($"Daily/Weekly Activities Not Found For The Selected Id {id}");
                }
                updateDailyActivities.Approved = dailyActivitiesList.Approved = true;
                updateDailyActivities.DateApproved = dailyActivitiesList.DateApproved;
                await _context.SaveChangesAsync();
                return Ok(updateDailyActivities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/DailyActivitiesLists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DailyActivitiesList>> PostDailyActivitiesList(DailyActivitiesList dailyActivitiesLists)
        {
            try
            {
                var dailyActivitiesList = new DailyActivitiesList
                {
                    DailyActivitiesId = dailyActivitiesLists.DailyActivitiesId,
                    DayDate = dailyActivitiesLists.DayDate,
                    DayDescription = dailyActivitiesLists.DayDescription,
                    WeekDayName = dailyActivitiesLists.WeekDayName,
                };
                _context.DailyActivitiesLists.Add(dailyActivitiesList);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostDailyActivitiesList", new { id = dailyActivitiesList.Id }, dailyActivitiesList);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Menu Name Already Exist");
            }
        }

        // DELETE: api/DailyActivitiesLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyActivitiesList>> DeleteDailyActivitiesList(int id)
        {
            var dailyActivitiesList = await _context.DailyActivitiesLists.FindAsync(id);
            if (dailyActivitiesList == null)
            {
                return NotFound();
            }

            _context.DailyActivitiesLists.Remove(dailyActivitiesList);
            await _context.SaveChangesAsync();

            return dailyActivitiesList;
        }

        private bool DailyActivitiesListExists(int id)
        {
            return _context.DailyActivitiesLists.Any(e => e.Id == id);
        }
    }
}
