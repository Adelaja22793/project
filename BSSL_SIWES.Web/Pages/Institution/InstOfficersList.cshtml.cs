using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web.Pages.Institution
{
    public class InstOfficersListModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public InstOfficersListModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<InstitutionOfficer> InstitutionOfficer { get; set; }
        public async Task OnGetAsync()
        {
            InstitutionOfficer = await _context.InstitutionOfficers.Include(x => x.Institution)
                .Where(c =>c.InstitutionId == c.Institution.Id).OrderBy(x =>x.InstitutionId).ToListAsync();
        }
        public ActionResult OnPostCreateNewStudent()
        {
            return RedirectToPage("./SetUpInstOfficer");
        }
    }
}