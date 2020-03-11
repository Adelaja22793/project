using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIWES_BSSL.Data;
using SIWES_BSSL.Data.Setup;

namespace SIWES_BSSL
{
    public class PolicySetupModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;

        public PolicySetupModel(SIWES_BSSL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PolicyTb PolicyTb { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PolicyTb.Add(PolicyTb);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}