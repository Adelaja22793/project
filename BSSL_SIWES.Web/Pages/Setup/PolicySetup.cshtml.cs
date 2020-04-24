using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        [BindProperty]
        public PolicyTb PolicyTb { get; set; }
        public List<PolicyTb> PolicyTbList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["InstituTypes"] = new SelectList(_context.InstTypeSetup, "Id", "Name");
            PolicyTbList = await _context.PolicyTb.ToListAsync();
            if (PolicyTbList == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        
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