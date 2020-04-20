using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiwesData;
using SiwesData.Employer;
using SiwesData.Students;

namespace BSSL_SIWES.Web.Pages.Students
{
    public class StudentBioDataModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public StudentBioDataModel(SiwesData.ApplicationDbContext context, SignInManager<AppUserTab> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public StudentSetUp StudentSetUp { get; set; }
        public DailyActivities DailyActivities { get; set; }
        public DailyActivitiesList DailyActivitiesList { get; set; }
        public Scaf Scaf { get; set; }
        public int StudentId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {

            //this gets the id from the AspNetUsers table
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");

            StudentSetUp = await _context.StudentSetUps.Include(c => c.Courses).Include(c => c.LGA).Include(c => c.Institution)
                .Include(c => c.InstitutionOfficer).Include(c =>c.EmployerSuperSetup).ThenInclude(c => c.AreaOffice)
                .Where(x => x.CoursesId == x.Courses.Id && x.Email == userEmail && x.LGA.Id == x.LGAId
                    && x.InstitutionId == x.Institution.Id && x.InstitutionOfficerId == x.InstitutionOfficer.Id
                    && x.EmployerSuperSetupId == x.EmployerSuperSetup.Id && x.EmployerSuperSetup.AreaOfficeId == x.EmployerSuperSetup.AreaOffice.Id).FirstOrDefaultAsync();

            Scaf = await _context.Scafs.Include(c => c.EmployerSupervisor).ThenInclude(c =>c.EmployerSuperSetup)
                                .Where(x => x.EmployerSupervisorId == x.EmployerSupervisor.Id 
                                && x.EmployerSupervisor.EmployerSuperSetupId == x.EmployerSupervisor.EmployerSuperSetup.Id && x.StudentSetUpId == StudentSetUp.Id)
                                .SingleOrDefaultAsync();

            if (StudentSetUp == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}