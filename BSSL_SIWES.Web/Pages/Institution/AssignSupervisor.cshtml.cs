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
using BSSL_SIWES.Web.ViewModels;
using SiwesData.Students;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;
using Microsoft.Extensions.Logging;

namespace BSSL_SIWES.Web.Pages.Institution
{
    public class AssignSupervisorModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public AssignSupervisorModel(SiwesData.ApplicationDbContext context, SignInManager<AppUserTab> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IList<InstitutionOfficer> InstitutionOfficers { get; set; }
        public SiwesData.Setup.InstitutionOfficer InstitutionOfficer { get; set; }
        public string Message { get; set; }
        public IList<StudentSetUp> ListOfStudent { get; set; }
        public async Task<IActionResult> OnGetAsync(int? InstitutionId)
        {
            //id = 10;
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);

            //InstitutionId = await _context.Institution.Where(x => x.Email == userEmail).Select(x => x.Id).FirstOrDefaultAsync();
            InstitutionId = await _context.InstitutionOfficers.Include(x => x.Institution)
               .Where(x => x.Email == userEmail && x.InstitutionId == x.Institution.Id).Select(x => x.InstitutionId).FirstOrDefaultAsync();

            InstitutionOfficer = await _context.InstitutionOfficers.Include(x => x.Institution)
                .Where(x => x.Email == userEmail && x.InstitutionId == x.Institution.Id).FirstOrDefaultAsync();
            if (InstitutionId == null)
            {
                return NotFound();
            }
            //Institution = await _context.Institution.Where(x => x.Id == id).SingleOrDefaultAsync();

            ListOfStudent = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.Institution)
                     .Where(x => x.InstitutionId == InstitutionId && x.Courses.Id == x.CoursesId 
                     && x.InstitutionId == x.Institution.Id).ToListAsync();

            InstitutionOfficers = await _context.InstitutionOfficers.Include(x => x.Institution)
                .Where(x => x.InstitutionId == x.Institution.Id && x.InstitutionId == InstitutionId
                 && x.OfficerType == "Supervisor" && x.Deactivate == false).ToListAsync();

            Message = "ALL STUDENT HAVE BEEN ASSIGNED SUPERVISOR OR THERE ARE NO STUDENT";
            return Page();
        }

    }
}