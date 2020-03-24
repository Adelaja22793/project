using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;

namespace BSSL_SIWES.Web.Pages.Setup
{
    public class InstitutionTypeSetupModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        [BindProperty]
        public InstTypeSetup InstTypeSetup { get; set; }
        public IList<InstTypeSetup> InstTypeSetupList { get; set; }
        public InstitutionTypeSetupModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            InstTypeSetupList = await _context.InstTypeSetup.ToListAsync();
            ViewData["Categories"] = new SelectList(_context.InstCatSetup, "Id", "Name");
            ViewData["SuperAgencies"] = new SelectList(_context.AgencySuperSetup, "Id", "Name");
        }
    }
}