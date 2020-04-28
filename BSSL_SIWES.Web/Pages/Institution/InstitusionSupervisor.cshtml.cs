using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;
using SiwesData.Students;
using SiwesData;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;
using Microsoft.Extensions.Logging;

namespace BSSL_SIWES.Web
{
    public class InstitusionSupervisorModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public InstitusionSupervisorModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager, ILogger<LoginModel> logger,
            SignInManager<AppUserTab> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IList<StudentSetUp> StudentSetUp { get; set; }
        public InstitutionOfficer InstitutionOfficer { get; set; }
        public async Task<IActionResult> OnGetAsync(int InstitutionOfficerId)
        {
            //id = 1;
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);

            InstitutionOfficerId = await _context.InstitutionOfficers.Where(x => x.Email == userEmail).Select(x => x.Id).FirstOrDefaultAsync();
            InstitutionOfficer = await _context.InstitutionOfficers.Where(x => x.Email == userEmail).FirstOrDefaultAsync();
            if (InstitutionOfficerId < 0)
            {
                return RedirectToPage("./InstitusionSupervisor");
            }
            //InstitutionOfficerId = await _context.InstitutionOfficers.FindAsync(id = 3);
            StudentSetUp = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.InstitutionOfficer).ThenInclude(x => x.Institution)
                .Where(x => x.Suspended == false && x.InstitutionOfficerId == InstitutionOfficerId)
                .ToListAsync();

            if (StudentSetUp == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}