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
using BSSL_SIWES.Web.ViewModels;
using SiwesData.Students;

namespace BSSL_SIWES.Web.Pages.Institution
{
    public class AssignSupervisorModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public AssignSupervisorModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<InstitutionOfficer> InstitutionOfficers { get; set; }
        public SiwesData.Setup.Institution Institution { get; set; }
        public string Message { get; set; }
        public IList<StudentSetUp> ListOfStudent { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            id = 10;
            if (id < 0)
            {
                return RedirectToPage("./CreateStudent");
            }
            Institution = await _context.Institution.Where(x => x.Id == id).SingleOrDefaultAsync();

            ListOfStudent = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.Institution)
                     .Where(x => x.InstitutionId == id && x.Courses.Id == x.CoursesId 
                     && x.InstitutionId == x.Institution.Id && x.InstitutionOfficerId == null).ToListAsync();

            InstitutionOfficers = await _context.InstitutionOfficers.Include(x => x.Institution)
                .Where(x => x.InstitutionId == x.Institution.Id && x.InstitutionId == id
                 && x.Deactivate == false).ToListAsync();

            Message = "ALL STUDENT HAVE BEEN ASSIGNED SUPERVISOR OR THERE ARE NO STUDENT";
            return Page();
        }

    }
}