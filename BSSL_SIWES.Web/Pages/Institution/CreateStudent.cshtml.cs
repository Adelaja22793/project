using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;
using SiwesData;

namespace BSSL_SIWES.Web
{
    public class CreateStudentModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateStudentModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Courses> ListOfCourses { get; set; }
        public string NewCourseToApprove { get; set; }
        public async Task OnGetAsync()
        {
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            ListOfCourses = await _context.Courses.ToListAsync();
            //var OfficerId = 1;
            //NewCourseToApprove = await _context.NewCourseRequests.Include(s => s.InstitiutionOfficer).Where(s => s.InstitiutionOfficer.Id == OfficerId);
            //if (PSess == null)
            //{
            //    Message = "No Present Session! Please ensure to add a Schools Present Session";
            //}
            //else
            //{
            //    Message = "Your Present Session is " + PSess.SessionName + "-" + PSess.Terms.Section;
            //}
            //return Page();
        }
        //public ActionResult OnPostDownloadFile()
        //{
        //    return File("/downloads/Form8.pdf", "application/octet-stream",
        //                "Form8.pdf");
        //}
    }
}