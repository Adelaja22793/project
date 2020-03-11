using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SIWES_BSSL.Data.Setup;

namespace SIWES_BSSL
{
    public class CourseSetupModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;

        [BindProperty]
        public Courses Courses { get; set; }
        public IList<Courses> CoursesList { get; set; }

        public CourseSetupModel(SIWES_BSSL.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            CoursesList = await _context.Courses.ToListAsync();
            // return Page();
        }
    }
}