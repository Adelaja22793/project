using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Data.Setup;

namespace BSSL_SIWES.Web.Pages.Setup
{
    public class InstitutionStudyLevelModel : PageModel
    {
        private readonly SiwesData.Data.ApplicationDbContext _context;

        [BindProperty]
        public InstLevelStudy InstLevelStudy { get; set; }
        public IList<InstLevelStudy> InstLevelStudyList { get; set; }

        public InstitutionStudyLevelModel(SiwesData.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            InstLevelStudyList = await _context.InstLevelStudy.ToListAsync();
            ViewData["Institution"] = new SelectList(_context.Institution,"Id","Name");
        }
    }
}