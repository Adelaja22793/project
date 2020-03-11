using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SIWES_BSSL.Data.Setup;

namespace SIWES_BSSL.Pages.Setup
{
    public class InstitutionCatSetupModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;
        
        [BindProperty]
        public InstCatSetup InstCatSetup { get; set; }
        public IList<InstCatSetup> InstCatSetups { get; set; }

        public InstitutionCatSetupModel(SIWES_BSSL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            InstCatSetups = await _context.InstCatSetup.ToListAsync();
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InstCatSetup.Add(InstCatSetup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
