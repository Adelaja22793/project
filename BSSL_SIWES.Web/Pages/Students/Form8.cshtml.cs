using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;

namespace BSSL_SIWES.Web
{
    public class Form8Model : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public Form8Model(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public StudentSetUp StudentSetUp { get; set; }
        public Scaf Scaf { get; set; }
        public Form8 Form8 { get; set; }
        public string StudentName { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            id = 19;
            if (id < 0)
            {
                return RedirectToPage("./Scaff_Form");
            }
            StudentSetUp = await _context.StudentSetUps.Include(c => c.Courses).Where(x => x.CoursesId == x.Courses.Id && x.Id == id).SingleOrDefaultAsync();
          Scaf = await _context.Scafs.Include(x => x.EmployerSupervisor).ThenInclude(x => x.EmployerSuperSetup)
                .Where(std => std.StudentSetUp.Id == std.StudentSetUpId && std.StudentSetUpId == StudentSetUp.Id
                && std.EmployerSupervisor.EmployerSuperSetupId == std.EmployerSupervisor.EmployerSuperSetup.Id).SingleOrDefaultAsync();
            StudentName = Scaf.StudentSetUp.Surname + ' ' + Scaf.StudentSetUp.OtherNames;
            if (Scaf == null)
            {
                return NotFound();
            }
            Form8 = await _context.Form8.Where(x => x.StudentSetUpId == Scaf.StudentSetUpId).SingleOrDefaultAsync();
            return Page();
        }
    }
}