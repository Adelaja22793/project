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
        public InstCarryCap InstCarryCap { get; set; }
        public IList<Courses> Courses { get; set; }
        public IList<CourseGrpSetup> CourseGrpSetup { get; set; }
        public IList<Courses> CoursesList { get; set; }
        public IList<InstCarryCap> InstCarryCapList { get; set; }
        public async Task OnGetAsync()
        {
            //CoursesList = await _context.Courses.Include(x => x.CourseGrpSetup)
            //     .Where(x => x.CourseGrpSetup.Id == x.CourseGrpSetupId)
            //     .OrderBy(x => x.Name).OrderBy(x => x.CourseGrpSetupId).ToListAsync();
           
            //InstCarryCapList = await _context.InstCarryCap.Include(x => x.Courses)
            //     .Where(x => x.Courses.Id == x.CoursesId).ToListAsync();
            InstCarryCapList = await _context.InstCarryCap.ToListAsync();
            ViewData["InstitutionList"] = new SelectList(_context.Institution, "Id", "Name");
            ViewData["CourseGroup"] = new SelectList(_context.CourseGrpSetup, "Id", "Name");
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Name");
           
        }
    }
}