using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIWES_BSSL.Data;
using SIWES_BSSL.Data.Setup;

namespace SIWES_BSSL
{
    public class CreateModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;

        public CreateModel(SIWES_BSSL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseGrpSetupId"] = new SelectList(_context.CourseGrpSetup, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Courses Courses { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Courses.Add(Courses);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}