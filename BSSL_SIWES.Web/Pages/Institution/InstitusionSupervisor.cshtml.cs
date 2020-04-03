using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;
using SiwesData.Students;

namespace BSSL_SIWES.Web
{
    public class InstitusionSupervisorModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public InstitusionSupervisorModel(SiwesData.ApplicationDbContext context,
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
                return RedirectToPage("./InstitusionSupervisor");
            }
            InstitutionOfficer = await _context.InstitutionOfficers.FindAsync(id = 3);
            StudentSetUp = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.InstitutionOfficer).ThenInclude(x => x.Institution)
                .Where(x => x.Suspended == false && x.InstitutionOfficerId == 3)
                .ToListAsync();

            if (StudentSetUp == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}