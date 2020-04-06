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
using SiwesData.Students;

namespace BSSL_SIWES.Web.Pages.Institution
{
    public class Student_Visit_FormModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Student_Visit_FormModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<StudentSetUp> StudentSetUp { get; set; }
        public InstitutionOfficer InstitutionOfficer { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            id = 1;
            if (id < 0)
            {
                return RedirectToPage("./Student_Visit_Form");
            }
            InstitutionOfficer = await _context.InstitutionOfficers.FindAsync(id = 19);
            StudentSetUp = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.InstitutionOfficer).ThenInclude(x => x.Institution)
                .Where(x => x.Suspended == false && x.InstitutionOfficerId == 19)
                .ToListAsync();

            if (StudentSetUp == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}