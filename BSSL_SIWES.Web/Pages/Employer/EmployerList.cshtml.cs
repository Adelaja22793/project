using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Employer;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerListModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public EmployerListModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<EmployerSuperSetup> EmployerSuperSetupList { get; set; }
        public async Task OnGetAsync()
        {
            EmployerSuperSetupList = await _context.EmployerSuperSetups.Include(x => x.LGA).ThenInclude(x =>x.State).ThenInclude(x =>x.Nationality)
                .Where(c => c.LGAId == c.LGA.Id && c.LGA.StateId == c.LGA.State.Id && c.LGA.State.Nationality.Id == c.LGA.State.NationalityId).ToListAsync();
        }
        public ActionResult OnPostCreateNewStudent()
        {
            return RedirectToPage("./EmployerSetup");
        }
    }
}