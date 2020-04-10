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

namespace BSSL_SIWES.Web
{
    public class CreateStudentModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateStudentModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public CreateStudentsViewModels CreateStudentsViewModels { get; set; }
        public ScafViewModels ScafViewModels { get; set; }
        public List<Courses> ListOfCourses { get; set; }
        public string NewCourseToApprove { get; set; }
        public Institution Institution { get; set; }
        public IList<StudentSetUp> ListOfStudent { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            id = 10;
            if (id < 0)
            {
                return RedirectToPage("./CreateStudent");
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            ListOfCourses = await _context.Courses.ToListAsync();
            Institution = await _context.Institution.Where(x => x.Id == id).SingleOrDefaultAsync();
            //id = 2;
            //ListOfStudent = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.InstitutionOfficer).Include(x => x.Institution)
            //    .Where(x => x.InstitutionOfficer.Institution.Id == id && x.CoursesId == x.Courses.Id && x.Suspended == false).ToListAsync();

            ListOfStudent = await _context.StudentSetUps.Include(x => x.Courses).Include(x =>x.Institution)
                     .Where(x => x.InstitutionId == id && x.Courses.Id == x.CoursesId && x.InstitutionId == x.Institution.Id).ToListAsync();


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
    }
}