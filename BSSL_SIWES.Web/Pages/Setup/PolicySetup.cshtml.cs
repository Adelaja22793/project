using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiwesData.Data;
using SiwesData.Data.Setup;

namespace BSSL_SIWES.Web
{
    public class PolicySetupModel : PageModel
    {
        private readonly SiwesData.Data.ApplicationDbContext _context;

        public PolicySetupModel(SiwesData.Data.ApplicationDbContext context)
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