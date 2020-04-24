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
namespace BSSL_SIWES.Web
{
    public class SupervisoryAgencyOfficerModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public SupervisoryAgencyOfficerModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public SupervisoryAgency SupervisoryAgency { get; set; }
        public AgencySuperSetup AgencySuperSetup { get; set; }
        
        public List<SupervisoryAgency> SupervisoryAgencyList { get; set; }
        //public InstCatSetup InstCatSetup { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["AgencySuperSetup"] = new SelectList(_context.AgencySuperSetup, "Id", "Name");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            SupervisoryAgencyList = await _context.SupervisoryAgencies.ToListAsync();
            if (SupervisoryAgencyList == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id, SupervisoryAgency supervisoryAgency)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.SupervisoryAgencies.Add(supervisoryAgency);
            await _context.SaveChangesAsync();
            ModelState.Clear();
           // return Page();
            return RedirectToPage("./SupervisoryAgencyOfficer");
        }
    }
}