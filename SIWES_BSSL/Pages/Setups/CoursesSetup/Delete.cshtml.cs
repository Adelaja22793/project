using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SIWES_BSSL.Data;
using SIWES_BSSL.Data.Setup;

namespace SIWES_BSSL
{
    public class DeleteModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;

        public DeleteModel(SIWES_BSSL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Courses Courses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses
                .Include(c => c.CourseGrpSetup).FirstOrDefaultAsync(m => m.Id == id);

            if (Courses == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.FindAsync(id);

            if (Courses != null)
            {
                _context.Courses.Remove(Courses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
