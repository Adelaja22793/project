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
namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerSupervisorModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;

        public EmployerSupervisorModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public EmployerSuperSetup EmployerName { get; set; }
        [BindProperty]
        public EmployerSupervisor EmployerSupervisor { get; set; }
        public IList<EmployerSupervisor> EmployerSupervisorsList { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            //dont know the id of ur employer so put the id
            id = 3;

            if (id < 0)
            {
                return Page();
            }

            EmployerName = await _context.EmployerSuperSetups.Where(c => c.Id == id).FirstOrDefaultAsync();
            EmployerSupervisorsList = await _context.EmployerSupervisors.Include(x =>x.EmployerSuperSetup)
                .Where(x =>x.EmployerSuperSetupId == x.EmployerSuperSetup.Id && x.EmployerSuperSetupId == id).ToListAsync();
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
            return RedirectToPage("./EmployerStudentList");
        }
    }
}
