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
    public class InstitutionSetupModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public InstitutionSetupModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public InstCatSetup InstCatSetup { get; set; }
        public List<InstTypeSetup> TypeSetupList { get; set; }
        public List<Institution> InstitutionList { get; set; }
        //public InstCatSetup InstCatSetup { get; set; }

        public async void OnGetAsync()
        {
            InstitutionList = await _context.Institution.ToListAsync();
            ViewData["Categories"] = new SelectList(_context.InstCatSetup, "Id", "Name");
            ViewData["Types"] = new SelectList(_context.InstTypeSetup, "Id", "Name");
            ViewData["SuperAgencies"] = new SelectList(_context.SupervisoryAgencies, "Id", "Name");
            ViewData["AreaOffices"] = new SelectList(_context.AreaOffices, "Id", "Name");
            //ViewData["AffililateInst"] = new SelectList(_context.Affililate, "Id", "Name");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
        }
    }
}