using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class PolicySetupModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;

        public PolicySetupModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["InstituTypes"] = new SelectList(_context.InstTypeSetup, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public PolicyTb PolicyTb { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id, PolicyTb PolicyTb)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.PolicyTb.Add(PolicyTb);
            await _context.SaveChangesAsync();
            ModelState.Clear();
            return Page();
           // return RedirectToPage("./Index");
        }
    }
}