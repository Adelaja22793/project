﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;

namespace BSSL_SIWES.Web.Pages.Institution
{
    public class StudentListModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public StudentListModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<StudentSetUp> ListOfStudent { get; set; }
        public async Task OnGetAsync(int id)
        {
            id = 2;
            ListOfStudent = await _context.StudentSetUps.Include(x => x.Courses).Include(x => x.InstitutionOfficer).ThenInclude(x =>x.Institution)
                .Where(x => x.InstitutionOfficer.Institution.Id == id && x.CoursesId == x.Courses.Id && x.Suspended == false).ToListAsync();
        }
        public ActionResult OnPostCreateNewStudent()
        {
            return RedirectToPage("./CreateStudent");
        }
    }
}