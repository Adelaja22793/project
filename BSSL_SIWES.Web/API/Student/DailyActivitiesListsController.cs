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
        public async Task<ActionResult<DailyActivitiesList>> GetDailyActivitiesList(int id)
        {
            var dailyActivitiesList = await _context.DailyActivitiesLists.FindAsync(id);

            if (dailyActivitiesList == null)
            {
                return NotFound();
            }

            return dailyActivitiesList;
        }

        // PUT: api/DailyActivitiesLists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyActivitiesList(int id, DailyActivitiesList dailyActivitiesList)
        {
            if (id != dailyActivitiesList.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyActivitiesList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyActivitiesListExists(id))
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
                    Day1 = dailyActivitiesLists.Day1,
                    Day1Description = dailyActivitiesLists.Day1Description,
                    Day2 = dailyActivitiesLists.Day2,
                    Day2Description = dailyActivitiesLists.Day2Description,
                    Day3 = dailyActivitiesLists.Day3,
                    Day3Description = dailyActivitiesLists.Day3Description,
                    Day4 = dailyActivitiesLists.Day4,
                    Day4Description = dailyActivitiesLists.Day4Description,
                    Day5 = dailyActivitiesLists.Day5,
                    Day5Description = dailyActivitiesLists.Day5Description,
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
