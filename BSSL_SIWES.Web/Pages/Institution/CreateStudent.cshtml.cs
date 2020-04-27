using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;
using SiwesData;
using BSSL_SIWES.Web.ViewModels;
using SiwesData.Students;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ExcelDataReader;
using System.Data;
using Microsoft.Extensions.Logging;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;

namespace BSSL_SIWES.Web
{
    public class CreateStudentModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly IHostingEnvironment _environment;
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        public CreateStudentModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager, IHostingEnvironment environment, ILogger<LoginModel> logger,
            SignInManager<AppUserTab> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
            _signInManager = signInManager;
            _logger = logger;
        }
        [BindProperty]
        public CreateStudentsViewModels CreateStudentsViewModels { get; set; }
        public ScafViewModels ScafViewModels { get; set; }
        public List<Courses> ListOfCourses { get; set; }
        public string NewCourseToApprove { get; set; }
        public InstitutionOfficer InstitutionOfficer { get; set; }
        public IList<StudentSetUp> ListOfStudent { get; set; }
        public IEnumerable<string> ImageFiles { get; set; }

        
        public async Task<IActionResult> OnGetAsync(int? InstitutionId)
        {
                    string imagePath =
                $"{_environment.WebRootPath}\\downloads";

                    this.ImageFiles = Directory.GetFiles
            (imagePath).Select(fileName => Path.GetFileName(fileName));

            //id = 11;
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);

            InstitutionId = await _context.InstitutionOfficers.Include(x =>x.Institution)
                .Where(x => x.Email == userEmail && x.InstitutionId == x.Institution.Id).Select(x => x.InstitutionId).FirstOrDefaultAsync();

            InstitutionOfficer = await _context.InstitutionOfficers.Include(x => x.Institution)
                .Where(x => x.Email == userEmail && x.InstitutionId == x.Institution.Id && x.OfficerType == "Coordinator").FirstOrDefaultAsync();

            if (InstitutionId == null)
            {
                return NotFound();
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            ListOfCourses = await _context.Courses.ToListAsync();

            ListOfStudent = await _context.StudentSetUps.Include(x => x.Courses).Include(x =>x.Institution)
                     .Where(x => x.InstitutionId == InstitutionId && x.Courses.Id == x.CoursesId 
                     && x.InstitutionId == x.Institution.Id).ToListAsync();


            return Page();
        }
        //public ActionResult OnPostDownloadFile()
        //{
        //    return File("/downloads/Form8.pdf", "application/octet-stream",
        //                "Form8.pdf");
        //}
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest("INSTITUTION NOT FOUND");
            }
            //Institution = await _context.Institution.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newStudentCreated = new StudentSetUp
            {
                MatricNumber = CreateStudentsViewModels.MatricNumber,
                Surname = CreateStudentsViewModels.Surname,
                OtherNames = CreateStudentsViewModels.OtherNames,
                MatricYear = CreateStudentsViewModels.MatricYear,
                CoursesId = CreateStudentsViewModels.CourseId,
                YearOfStudy = CreateStudentsViewModels.LevelStudy,
                LGAId = CreateStudentsViewModels.LGAId,
                PhoneNo = CreateStudentsViewModels.PhoneNumber,
                Email = CreateStudentsViewModels.Email,
                InstitutionId = id,
                StudentType=CreateStudentsViewModels.StudentType,
                SiwesYear = CreateStudentsViewModels.SiwesYear,
                BatchNo = CreateStudentsViewModels.BatchNo
            };
            _context.StudentSetUps.Add(newStudentCreated);
            await _context.SaveChangesAsync();

            return Redirect("./StudentList?id=" + id);
        }
        public async Task<IActionResult> OnPostUpdateStudentRecordsAsync(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newStudentCreated = new StudentSetUp
            {
                MatricNumber = CreateStudentsViewModels.MatricNumber,
                Surname = CreateStudentsViewModels.Surname,
                OtherNames = CreateStudentsViewModels.OtherNames,
                MatricYear = CreateStudentsViewModels.MatricYear,
                CoursesId = CreateStudentsViewModels.CourseId,
                YearOfStudy = CreateStudentsViewModels.LevelStudy,
                //NationalityId = CreateStudentsViewModels.NationalityId,
                //NationalityId = CreateStudentsViewModels.NationalityId,
                //StateId = CreateStudentsViewModels.StateId,
                PhoneNo = CreateStudentsViewModels.PhoneNumber,
                Email = CreateStudentsViewModels.Email,
                //InstitutionOfficerId = CreateStudentsViewModels.InstitutionOfficerId,
                StudentType = CreateStudentsViewModels.StudentType,
                SiwesYear = CreateStudentsViewModels.SiwesYear,
                BatchNo = CreateStudentsViewModels.BatchNo
            };
            _context.StudentSetUps.Add(newStudentCreated);
            await _context.SaveChangesAsync();

            return RedirectToPage("./StudentList?id=" + Id);
        }
        public ActionResult OnPostViewListOfStudent()
        {
            return RedirectToPage("./StudentList");
        }
        public ActionResult OnPostDownloadFile()
        {
            return File("/downloads/StudentListFormat.xlsx", "application/octet-stream",
                        "StudentListFormat.xlsx");
        }

        

    }
}