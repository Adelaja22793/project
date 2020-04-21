using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;
using SiwesData;
using Microsoft.Extensions.Logging;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;
using SiwesData.Employer;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerForm8Model : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public EmployerForm8Model(SiwesData.ApplicationDbContext context, SignInManager<AppUserTab> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IList<Scaf> Scafs { get; set; }
        //public int EmployerSupervisorId { get; set; }
        public async Task OnGetAsync(int? EmployerSupervisorId)
        {
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);

            EmployerSupervisorId = await _context.EmployerSupervisors.Where(x => x.Email == userEmail).Select(x => x.Id).FirstOrDefaultAsync();

      
            Scafs = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
               .Where(x => x.EmployerSupervisorId == EmployerSupervisorId && x.Suspended == false).ToListAsync();
        }
    }
}