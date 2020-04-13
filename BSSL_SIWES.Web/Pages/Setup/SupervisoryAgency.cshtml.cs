using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class SupervisoryAgencyModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public SupervisoryAgencyModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public AgencySuperSetup AgencySuperSetup { get; set; }
        public List<AgencySuperSetup> AgencySuperSetupList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            AgencySuperSetupList = await _context.AgencySuperSetup.ToListAsync();
            if (AgencySuperSetupList == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}