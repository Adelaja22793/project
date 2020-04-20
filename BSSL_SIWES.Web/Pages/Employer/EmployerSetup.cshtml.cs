using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Employer;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerSetupModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;

        public EmployerSetupModel(SiwesData.ApplicationDbContext context, 
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public EmployerSuperSetup EmployerSuperSetup { get; set; }
        public List<EmployerSuperSetup> EmployerSuperSetupList { get; set; }
        public IList<NewCourseRequest> NewCourseToApprove { get; set; }
        public string MessageAlert { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            ViewData["Areaoffice"] = new SelectList(_context.AreaOffices, "Id", "Description");
            ViewData["BusinessLine"] = new SelectList(_context.businessLine, "Id", "Description");

            EmployerSuperSetupList = await _context.EmployerSuperSetups.ToListAsync();
            NewCourseToApprove = await _context.NewCourseRequests.Where(app => app.Approved == false && app.ReqstType == "employer").ToListAsync();
            MessageAlert = $"You have {NewCourseToApprove.Count()} Employer(s) Recommended to Setup";
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int? id, EmployerSuperSetup employerSuperSetup)
        {
            var newEmployer = new EmployerSuperSetup
            {
                Code = employerSuperSetup.Code,
                Name = employerSuperSetup.Name,
                Address1 = employerSuperSetup.Address1,
                Address2 = employerSuperSetup.Address2,
                PhoneNo = employerSuperSetup.PhoneNo,
                PhoneNo2 = employerSuperSetup.PhoneNo2,
                Email = employerSuperSetup.Email,
                //NationalityId = employerSuperSetup.NationalityId,
                //StateId = employerSuperSetup.StateId,
                LGAId= employerSuperSetup.LGAId,
                CoporationType = employerSuperSetup.CoporationType,
                BusinessLineId = employerSuperSetup.BusinessLineId,
                BusinessType = employerSuperSetup.BusinessType,
                YearOfIncop = employerSuperSetup.YearOfIncop,
                AreaOfficeId = employerSuperSetup.AreaOfficeId,
                WebAddress = employerSuperSetup.WebAddress,
            };
            _context.EmployerSuperSetups.Add(newEmployer);
            await _context.SaveChangesAsync();
            ModelState.Clear();
            return Page();
        }
    }
}
