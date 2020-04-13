using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;
using SiwesData;
namespace BSSL_SIWES.Web.Pages.Institution
{
    public class SupervisorListModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public SupervisorListModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<StudentSetUp> ListOfStudent { get; set; }
        public async Task OnGetAsync(int id)
        {
            id = 19;
            ListOfStudent = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.InstitutionOfficer).ThenInclude(x => x.Institution)
                .Where(x => x.InstitutionOfficerId == id && x.CoursesId == x.Courses.Id && x.Suspended == false).ToListAsync();
        }
        public ActionResult OnPostCreateNewStudent()
        {
            return RedirectToPage("./Student_Visit_Form");
        }
    }
}