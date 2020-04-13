using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SiwesData.Employer;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerSupervisorListModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public EmployerSupervisorListModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<EmployerSupervisor> EmployerSupervisorsList { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EmployerSupervisorsList = await _context.EmployerSupervisors.Include(x => x.EmployerSuperSetup)
                .Where(x => x.EmployerSuperSetupId == x.EmployerSuperSetup.Id && x.EmployerSuperSetupId == id).ToListAsync();
            if (EmployerSupervisorsList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}