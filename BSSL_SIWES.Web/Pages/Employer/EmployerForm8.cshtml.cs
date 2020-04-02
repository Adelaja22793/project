using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerForm8Model : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployerForm8Model(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<Scaf> Scafs { get; set; }
        public async Task OnGetAsync(int? id)
        {
            id = 1;
            //ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            Scafs = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
               .Where(x => x.EmployerSupervisorId == id && x.Suspended == false).ToListAsync();
        }
    }
}