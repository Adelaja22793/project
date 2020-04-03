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
        private readonly UserManager<IdentityUser> _userManager;
        public SupervisoryAgencyModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public AgencySuperSetup AgencySuperSetup { get; set; }
        public List<AgencySuperSetup> AgencySuperSetupList { get; set; }
        public async void OnGetAsync()
        {
            AgencySuperSetupList = await _context.AgencySuperSetup.ToListAsync();
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
        }
    }
}