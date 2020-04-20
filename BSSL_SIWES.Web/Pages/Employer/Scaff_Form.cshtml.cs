using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSSL_SIWES.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Employer;
using SiwesData.Setup;
using SiwesData.Students;
using SiwesData;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;
using Microsoft.Extensions.Logging;

namespace BSSL_SIWES.Web.Pages.Employer
{
    public class Scaff_FormModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public Scaff_FormModel(SiwesData.ApplicationDbContext context, SignInManager<AppUserTab> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [BindProperty]
        public ScafViewModels ScafViewModels { get; set; }
        public IList<StudentSetUp> StudentSetUp { get; set; }
        [BindProperty]
        public Scaf Scafs  { get; set; }
        [BindProperty]
        public StudentSetUp StudentAttached { get; set; }
        public EmployerSuperSetup EmployerName { get; set; }
        public EmployerSupervisor EmployerSupervisorName { get; set; }
        public List<EmployerSuperSetup> EmployerSuperSetup { get; set; }
        public List<EmployerSupervisor> EmployerSupervisor { get; set; }
        //public Data.set.EmployerSupervisor EmployerSupervisor { get; set; }
        //public Institution Institution { get; set; }
        public CourseGrpSetup CourseGrp { get; set; }
        public string Message { get; set; }
        public string StudentName { get; set; }
        public IList<StudentSetUp> AttachedList { get; set; }
        public string MessageAlert { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            //this gets the id from the AspNetUsers table
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);
            //id = 1;
            if (userEmail == null)
            {
                return RedirectToPage("./Scaff_Form");
            }
            EmployerSuperSetup = await _context.EmployerSuperSetups.ToListAsync();

            EmployerName = await _context.EmployerSuperSetups.Include(x => x.AreaOffice).Where(c => c.AreaOfficeId == c.AreaOffice.Id 
                            && c.Code == userEmail).FirstOrDefaultAsync();

            EmployerSupervisor = await _context.EmployerSupervisors.Include(e => e.EmployerSuperSetup)
                .Where(employerName => employerName.EmployerSuperSetupId == EmployerName.Id).ToListAsync();

            EmployerSupervisorName = await _context.EmployerSupervisors.Include(super => super.EmployerSuperSetup)
                                    .Where(super => super.EmployerSuperSetupId == EmployerName.Id).FirstOrDefaultAsync();
           
            StudentSetUp = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.InstitutionOfficer).ThenInclude(x => x.Institution)
                           .Where(x => x.Suspended == false && x.Attached == false && x.InstitutionOfficerId != null).ToListAsync();

            AttachedList = await _context.StudentSetUps.Include(c =>c.Courses).Include(inst =>inst.Institution)
                            .Where(x =>x.CoursesId == x.Courses.Id && x.InstitutionId == x.Institution.Id)
                            .Where(att => att.Attached == false && att.EmployerSuperSetupId == EmployerName.Id).ToListAsync();

            MessageAlert = $"You have {AttachedList.Count()} Student(s) Attached to Your Organization";

            if (StudentSetUp == null)
            {
                return NotFound();
            }

            return Page();

        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest("INSTITUTION NOT FOUND");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var NewScaf = new Scaf
            {
                StudentSetUpId = ScafViewModels.StudentId,
                Commence_Date = ScafViewModels.CommenceDate,
                Complete_Date = ScafViewModels.CompletionDate,
                Duration = ScafViewModels.Duration,
                EmployerSupervisorId = ScafViewModels.EmployerSupervisorId,
                Remarks = ScafViewModels.Remarks,
            };
            _context.Scafs.Add(NewScaf);
            await _context.SaveChangesAsync();

            var studentId = NewScaf.StudentSetUpId;
            
            var studentTab = await _context.StudentSetUps.FirstOrDefaultAsync(m => m.Id == studentId);
            studentTab.Attached = StudentAttached.Attached = true;
            await _context.SaveChangesAsync();

            return Redirect("./EmployerStudentList?id=" + id);
        }
        public ActionResult OnPostDownloadFile()
        {
            return File("/downloads/Scaf.pdf", "application/octet-stream",
                        "Scaf.pdf");
        }
    }
}