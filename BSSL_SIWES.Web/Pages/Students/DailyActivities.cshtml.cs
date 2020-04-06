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
using SiwesData.Students;

namespace BSSL_SIWES.Web
{
    public class DailyActivitiesModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        
        public DailyActivitiesModel(SiwesData.ApplicationDbContext context, SignInManager<IdentityUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public List<SelectListItem> SelectMonth { get; set; }
        public DailyActivities DailyActivities { get; set; }
        public DailyActivitiesList DailyActivitiesList { get; set; }
        public Scaf Scaf { get; set; }
        public int StudentId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
           
            //this gets the id from the AspNetUsers table
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail =  _userManager.GetUserName(User);

            StudentId = await _context.StudentSetUps.Where(x => x.Email == userEmail).Select(x =>x.Id).FirstOrDefaultAsync();

            Scaf = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
                .Where(x => x.StudentSetUpId == x.StudentSetUp.Id && x.EmployerSupervisorId == x.EmployerSupervisor.Id
                && x.StudentSetUpId == StudentId).SingleOrDefaultAsync();
            if (Scaf == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}