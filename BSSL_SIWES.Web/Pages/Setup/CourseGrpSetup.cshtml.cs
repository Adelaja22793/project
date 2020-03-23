using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Data.Setup;

namespace BSSL_SIWES.Web.Pages.Setup
{
    public class CourseGrpSetupModel : PageModel
    {
        private readonly SiwesData.Data.ApplicationDbContext _context;

        [BindProperty]
        public CourseGrpSetup CourseGrpSetup { get; set; }
        public IList<CourseGrpSetup> CourseGrpSetupList { get; set; }

        public CourseGrpSetupModel(SiwesData.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            CourseGrpSetupList = await _context.CourseGrpSetup.ToListAsync();
            ViewData["InstituTypes"] = new SelectList(_context.InstTypeSetup, "Id", "Name");
        }
    }
}