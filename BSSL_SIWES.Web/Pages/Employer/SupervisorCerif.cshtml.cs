using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;
using SiwesData.Employer;

using SiwesData;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;
using Microsoft.Extensions.Logging;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class SupervisorCerifModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public SupervisorCerifModel(SiwesData.ApplicationDbContext context, SignInManager<AppUserTab> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public List<SelectListItem> StudentName { get; set; }
        public IList<Scaf> Scafs { get; set; }
        public EmployerSupervisor EmployerSupervisor { get; set; }
        public List<SelectListItem> SelectMonth { get; set; }
        public async Task OnGetAsync(int? EmployerSupervisorId)
        {
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);

            EmployerSupervisorId = await _context.EmployerSupervisors.Where(x => x.Email == userEmail).Select(x => x.Id).FirstOrDefaultAsync();

            SelectMonth = new List<SelectListItem>
            {
                new SelectListItem { Value = "January", Text = "January" },
                new SelectListItem { Value = "February", Text = "February" },
                new SelectListItem { Value = "March", Text = "March" },
                new SelectListItem { Value = "April", Text = "April" },
                new SelectListItem { Value = "May", Text = "May" },
                new SelectListItem { Value = "June", Text = "June" },
                new SelectListItem { Value = "July", Text = "July" },
                new SelectListItem { Value = "August", Text = "August" },
                new SelectListItem { Value = "September", Text = "September" },
                new SelectListItem { Value = "October", Text = "October" },
                new SelectListItem { Value = "November", Text = "November" },
                new SelectListItem { Value = "December", Text = "December" },
            };

            Scafs = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
                .Where(x => x.EmployerSupervisorId == EmployerSupervisorId && x.StudentSetUp.Suspended == false).ToListAsync();
        }
    }
}