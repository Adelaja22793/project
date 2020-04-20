using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class SupervisoryAgencyModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public SupervisoryAgencyModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public AgencySuperSetup AgencySuperSetup { get; set; }
        public List<AgencySuperSetup> AgencySuperSetupList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            AgencySuperSetupList = await _context.AgencySuperSetup.ToListAsync();
            if (AgencySuperSetupList == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id, AgencySuperSetup AgencySuperSetup)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var newAgencySuperSetup = new AgencySuperSetup
            //{
            //    Code = AgencySuperSetup.Code,
            //    ShortCode = AgencySuperSetup.ShortCode,
            //    Name = AgencySuperSetup.Name,
            //    Address1 = AgencySuperSetup.Address1,
            //    Address2 = AgencySuperSetup.Address2,
            //    Country = AgencySuperSetup.Country,
            //    State = AgencySuperSetup.State,
            //    City = AgencySuperSetup.City,
            //    ZipCode = AgencySuperSetup.ZipCode,
            //    PhoneNo = AgencySuperSetup.PhoneNo,
            //    Email = AgencySuperSetup.Email,
            //    WebAddress = AgencySuperSetup.WebAddress,
            //    NameOfCPerson = AgencySuperSetup.NameOfCPerson,
            //    CPersonPhone = AgencySuperSetup.CPersonPhone,
            //    CPersonEmail = AgencySuperSetup.CPersonEmail,
            //    Deactivate = AgencySuperSetup.Deactivate ="0",
            //    //Datedectivated = AgencySuperSetup.Datedectivated,
            //};
            _context.AgencySuperSetup.Add(AgencySuperSetup);
            await _context.SaveChangesAsync();
            ModelState.Clear();
            return Page();
        }
    }
}