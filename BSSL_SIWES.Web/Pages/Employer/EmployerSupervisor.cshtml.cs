using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Employer;
using Microsoft.AspNetCore.Identity;
using SiwesData;
using Microsoft.Extensions.Logging;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerSupervisorModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public EmployerSupervisorModel(SiwesData.ApplicationDbContext context, SignInManager<AppUserTab> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public EmployerSuperSetup EmployerName { get; set; }
        [BindProperty]
        public EmployerSupervisor EmployerSupervisor { get; set; }
        public IList<EmployerSupervisor> EmployerSupervisorsList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            //this gets the id from the AspNetUsers table
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);
            if (userEmail ==  null)
            {
                return Page();
            }

            EmployerName = await _context.EmployerSuperSetups.Where(c => c.Code == userEmail || c.Email == userEmail).FirstOrDefaultAsync();
            EmployerSupervisorsList = await _context.EmployerSupervisors.Include(x =>x.EmployerSuperSetup)
                .Where(x =>x.EmployerSuperSetupId == x.EmployerSuperSetup.Id && x.EmployerSuperSetupId == EmployerName.Id).ToListAsync();
            if (EmployerName == null)
            {
                return NotFound();
            }
            return Page();

        }
        public async Task<IActionResult> OnPostAsync(int? id, EmployerSupervisor employerSupervisor)
        {
            var newEmployerSupervisor = new EmployerSupervisor
            {
                Name = employerSupervisor.Name,
                Designation = employerSupervisor.Designation,
                IndBaseCode = employerSupervisor.IndBaseCode,
                Phone1 = employerSupervisor.Phone1,
                Phone2 = employerSupervisor.Phone2,
                Email = employerSupervisor.Email,
                EmployerSuperSetupId = id,
            };
            _context.EmployerSupervisors.Add(newEmployerSupervisor);
            await _context.SaveChangesAsync();
            return Redirect("./EmployerSupervisorList?id=" + id);
        }
    }
}
