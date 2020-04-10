using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;

namespace BSSL_SIWES.Web.Pages.Setup
{
    public class InstitutionCapacityModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        public InstitutionCapacityModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InstTypeSetup InstTypeSetup { get; set; }
        public IList<Courses> CoursesList { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["InstitutionList"] = new SelectList(_context.Institution, "Id", "Name");
            ViewData["CourseGroup"] = new SelectList(_context.CourseGrpSetup, "Id", "Name");
            CoursesList = await _context.Courses.Include(x => x.CourseGrpSetup).Where(x => x.CourseGrpSetup.Id == x.CourseGrpSetupId)
               .OrderBy(x => x.Name).OrderBy(x => x.CourseGrpSetupId).ToListAsync();
           
        }
    }
}