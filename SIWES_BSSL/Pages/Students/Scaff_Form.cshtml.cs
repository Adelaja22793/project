using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SIWES_BSSL.Data.Students;

namespace SIWES_BSSL
{
    public class Scaff_FormModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Scaff_FormModel(SIWES_BSSL.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public StudentSetUp StudentSetUp { get; set; }
        [BindProperty]
        public Scaf Scafs  { get; set; }
        public List<Data.Employer.EmployerSuperSetup> EmployerSuperSetup { get; set; }
        public List<Data.Employer.EmployerSupervisor> EmployerSupervisor { get; set; }
        //public Data.set.EmployerSupervisor EmployerSupervisor { get; set; }
        public Data.Setup.Institution Institution { get; set; }
        public Data.Setup.CourseGrpSetup CourseGrp { get; set; }
        public string Message { get; set; }
        public string StudentName { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            id = 1;
            if (id < 0)
            {
                return RedirectToPage("./AcBiodata");
            }
            EmployerSuperSetup = await _context.EmployerSuperSetups.ToListAsync();

            EmployerSupervisor = await _context.EmployerSupervisors.Include(e =>e.EmployerSuperSetup)
                .Where(employerName => employerName.EmployerSuperSetup.Id == employerName.Id).ToListAsync();

            StudentSetUp = await _context.StudentSetUps.Include( x => x.Courses).Include(x =>x.Institution)
                .Where(x => x.Id == id && x.Courses.Id == x.CoursesId && x.Institution.Id == x.InstitutionId).FirstOrDefaultAsync();

            StudentName = StudentSetUp.Surname + ' ' + StudentSetUp.OtherNames;
            if (StudentSetUp == null)
            {
                return NotFound();
            }

            return Page();

        }
    }
}