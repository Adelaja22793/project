using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class CourseSetupModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;

        [BindProperty]
        public Courses Courses { get; set; }
        public IList<Courses> CoursesList { get; set; }
        public IList<NewCourseRequest> NewCourseToApprove { get; set; }
        public string MessageAlert { get; set; }

        public CourseSetupModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            CoursesList = await _context.Courses.Include(x =>x.CourseGrpSetup).Where(x =>x.CourseGrpSetup.Id == x.CourseGrpSetupId)
               .OrderBy(x => x.Name).OrderBy(x => x.CourseGrpSetupId).ToListAsync();
            ViewData["CourseGroup"] = new SelectList(_context.CourseGrpSetup, "Id", "Name");

            NewCourseToApprove = await _context.NewCourseRequests.Where(app => app.Approved == false && app.ReqstType == "course").ToListAsync();
            MessageAlert = $"You have {NewCourseToApprove.Count()} Course(s) Recommended to Setup";
            
        }
    }
}