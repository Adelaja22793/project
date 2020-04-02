using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

//namespace BSSL_SIWES.Web.API.Courses_
namespace BSSL_SIWES.Web.API.Courses_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCourseRequestsController : ControllerBase
    {
        public class RequestedCourse
        {
            public string Name { get; set; }
            public bool Approval { get; set; }
            public DateTime ApprovalDate { get; set; }
            public DateTime DateIn { get; set; }
            public int InstitiutionOfficerId { get; set; }
            public string ApprovedBy { get; set; }
        }
        private readonly ApplicationDbContext _context;

        public NewCourseRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NewCourseRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewCourseRequest>>> GetNewCourseRequests()
        {
            return await _context.NewCourseRequests.ToListAsync();
        }

        // GET: api/NewCourseRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewCourseRequest>> GetNewCourseRequest(int? id)
        {
            if (id == null)
            {
                return BadRequest("Daily/Weekly Activities is Empty");
            }
            try
            {
                var dailyActivitiesList = await _context.DailyActivitiesLists.Include(x => x.DailyActivities)
                    .SingleOrDefaultAsync(x => x.DailyActivitiesId == x.DailyActivities.Id && x.Id == id);

                if (dailyActivitiesList == null)
                {
                    return NotFound($"Menu Not Found For The Selected Id {id}");
                }
                return Ok(dailyActivitiesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            var newCourseRequest = await _context.NewCourseRequests.FindAsync(id);

            if (newCourseRequest == null)
            {
                return NotFound();
            }

            return newCourseRequest;
        }

        // PUT: api/NewCourseRequests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewCourseRequest(int? id, NewCourseRequest newCourseRequest)
        {
            if (id == null)
            {
                return BadRequest("CourseId is Empty");
            }

            try
            {
                var updateApproval = await _context.NewCourseRequests.FirstOrDefaultAsync(m => m.Id == id);

                if (updateApproval == null)
                {
                    return NotFound($"Course Not Found For The Selected Id {id}");
                }
                updateApproval.Approved = newCourseRequest.Approved = true;
                updateApproval.ApprovedBy = newCourseRequest.ApprovedBy;
                updateApproval.ApprovedDate = newCourseRequest.ApprovedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(updateApproval);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //if (id != newCourseRequest.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(newCourseRequest).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!NewCourseRequestExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/NewCourseRequests
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
                    InstitiutionOfficerId = newCourseRequest.InstitiutionOfficerId,
                };
                _context.NewCourseRequests.Add(newCourseRecom);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostNewCourseRequest", new { id = newCourseRecom.Id }, newCourseRecom);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, $"{newCourseRequest.Name} HAS BEEN SENT FOR SETUP, PREVIOUSLY, PLEASE CHECK!!!");
            }




            //_context.NewCourseRequests.Add(newCourseRequest);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetNewCourseRequest", new { id = newCourseRequest.Id }, newCourseRequest);
        }

        // DELETE: api/NewCourseRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewCourseRequest>> DeleteNewCourseRequest(int? id, RequestedCourse courseDeleted)
        {
            if (id == null)
            {
                return BadRequest("CourseID is Empty");
            }

            try
            {
                var RequestedCourse = await _context.NewCourseRequests.FindAsync(id);
                if (RequestedCourse == null)
                {
                    return NotFound($"Course Not Found For The Selected Id {id}");
                }
                _context.NewCourseRequests.Remove(RequestedCourse);
                await _context.SaveChangesAsync();
                RequestedCourse.Name = courseDeleted.Name;
                //return DeleteMenu(id, menu.Name);
                return Ok(RequestedCourse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

            //var newCourseRequest = await _context.NewCourseRequests.FindAsync(id);
            //if (newCourseRequest == null)
            //{
            //    return NotFound();
            //}

            //_context.NewCourseRequests.Remove(newCourseRequest);
            //await _context.SaveChangesAsync();

            //return newCourseRequest;
        }

        private bool NewCourseRequestExists(int id)
        {
            return _context.NewCourseRequests.Any(e => e.Id == id);
        }
    }
}
