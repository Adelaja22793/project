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

namespace BSSL_SIWES.Web.Pages.Institution
{
    public class SetUpInstOfficerModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;

        public SetUpInstOfficerModel(SiwesData.ApplicationDbContext context,
          UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public SiwesData.Setup.Institution InstitionNmae;
        public IList<InstitutionOfficer> InstitutionOfficers { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            id = 1;

            if (id < 0)
            {
                return Page();
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            InstitionNmae = await _context.Institution.Where(c => c.Id == id)
          .FirstOrDefaultAsync();

            InstitutionOfficers = await _context.InstitutionOfficers.Include(c => c.Institution)
                .Where(x => x.InstitutionId == x.Institution.Id && x.InstitutionId == id).ToListAsync();

            if (InstitionNmae == null)
            {
                return NotFound();

            }
            return Page();
        }
    }
}