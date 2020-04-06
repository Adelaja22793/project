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
    public class DailyActivitiesListsDateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DailyActivitiesListsDateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyActivitiesListsDate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyActivitiesList>>> GetDailyActivitiesLists()
        {
            return await _context.DailyActivitiesLists.ToListAsync();
        }

        // GET: api/DailyActivitiesListsDate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyActivitiesList>> GetDailyActivitiesList(int? id)
        {
            if (id == null)
            {
                return BadRequest("No Daily Activities Record For This Student");
            }
            try
            {
                var dailyActivitiesList = await _context.DailyActivitiesLists
                    .Where(x => x.DailyActivitiesId == id).ToListAsync();
                //.FindAsync(id);

                if (dailyActivitiesList == null)
                {
                    return NotFound($"Daily/Weekly Activities Not Found For The Selected Id {id}");
                }
                return Ok(dailyActivitiesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/DailyActivitiesListsDate/5
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

        // POST: api/DailyActivitiesListsDate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DailyActivitiesList>> PostDailyActivitiesList(DailyActivitiesList dailyActivitiesList)
        {
            _context.DailyActivitiesLists.Add(dailyActivitiesList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyActivitiesList", new { id = dailyActivitiesList.Id }, dailyActivitiesList);
        }

        // DELETE: api/DailyActivitiesListsDate/5
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
