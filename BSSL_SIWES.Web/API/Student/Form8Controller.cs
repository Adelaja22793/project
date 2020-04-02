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
    public class Form8Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Form8Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Form8
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form8>>> GetForm8()
        {
            return await _context.Form8.ToListAsync();
        }

        // GET: api/Form8/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Form8>> GetForm8(int id)
        {
            var scaf = await _context.Form8.Include(x => x.StudentSetUp)
             //.ThenInclude(x =>x.)
             .Where(x => x.StudentSetUpId == id && x.StudentSetUp.Id == x.StudentSetUpId).SingleOrDefaultAsync();

            //if (scaf == null)
            //{
            //    return NotFound();
            //}

            return scaf;
            
        }

        // PUT: api/Form8/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForm8(int? id, Form8 form8)
        {
            if (id == null)
            {
                return BadRequest("No Record to Update");
            }

            try
            {
                var updateForm8 = await _context.Form8.FirstOrDefaultAsync(m => m.StudentSetUpId == id);

                if (updateForm8 == null)
                {
                    return NotFound($"Record Not Found For The Selected Id {id}");
                }
                updateForm8.WorkExperience = form8.WorkExperience;
                await _context.SaveChangesAsync();
                return Ok(updateForm8);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Form8
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Form8>> PostForm8(Form8 form8)
        {
            try
            {
                var newForm8 = new Form8
                {
                    StudentSetUpId = form8.StudentSetUpId,
                    WorkExperience = form8.WorkExperience
                };
                _context.Form8.Add(newForm8);
                await _context.SaveChangesAsync();


                return CreatedAtAction("PostForm8", new { id = newForm8.Id }, newForm8);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Form8/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Form8>> DeleteForm8(int id)
        {
            var form8 = await _context.Form8.FindAsync(id);
            if (form8 == null)
            {
                return NotFound();
            }

            _context.Form8.Remove(form8);
            await _context.SaveChangesAsync();

            return form8;
        }

        private bool Form8Exists(int id)
        {
            return _context.Form8.Any(e => e.Id == id);
        }
    }
}
