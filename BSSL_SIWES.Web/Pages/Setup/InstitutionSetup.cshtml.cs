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
        [BindProperty]
        public InstCatSetup InstCatSetup { get; set; }
        public Institution Institution { get; set; }
        public List<InstTypeSetup> TypeSetupList { get; set; }
        public List<Institution> InstitutionList { get; set; }
        //public InstCatSetup InstCatSetup { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["Categories"] = new SelectList(_context.InstCatSetup, "Id", "Name");
            ViewData["Types"] = new SelectList(_context.InstTypeSetup, "Id", "Name");
            ViewData["SuperAgencies"] = new SelectList(_context.SupervisoryAgencies, "Id", "Name");
            ViewData["AreaOffices"] = new SelectList(_context.AreaOffices, "Id", "Description");
            //ViewData["AffililateInst"] = new SelectList(_context.Affililate, "Id", "Name");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            InstitutionList = await _context.Institution.ToListAsync();
            if (InstitutionList == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id, Institution Institution)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var newInstitution = new Institution
            //{
            //    Code = Institution.Code,
            //    ShortCode = Institution.ShortCode,
            //    Name = Institution.Name,
            //    Address1 = Institution.Address1,
            //    Address2 = Institution.Address2,
            //    Country = Institution.Country,
            //    State = Institution.State,
            //    City = Institution.City,
            //    ZipCode = Institution.ZipCode,
            //    PhoneNo1 = Institution.PhoneNo1,
            //    PhoneNo2 = Institution.PhoneNo2,
            //    Email = Institution.Email,
            //    Website = Institution.Website,
            //    Superagency = Institution.Superagency,
            //    AreaOffice = Institution.AreaOffice,
            //    AffiliateInst = Institution.AffiliateInst,
            //    CapacityNo = Institution.CapacityNo,
            //    Deactivate = Institution.Deactivate="0",
            //    //Datedectivated = Institution.Datedectivated,
            //    InstTypeSetupId = Institution.InstTypeSetupId
            //};
            _context.Institution.Add(Institution);
            await _context.SaveChangesAsync();
            ModelState.Clear();
            return Page();
        }
    }
}