﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Employer;
using SiwesData.Students;
using SiwesData;
namespace BSSL_SIWES.Web.Pages.Employer
{
    public class EmployerStudentListModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        public EmployerStudentListModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<Scaf> EmpoyerStudentList { get; set; }
        public EmployerSupervisor Employers { get; set; }
        public async Task OnGetAsync(int id)
        {
           
            EmpoyerStudentList = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
                .ThenInclude(x => x.EmployerSuperSetup)
                .Where(x => x.EmployerSupervisor.EmployerSuperSetupId == id && x.Suspended == false).ToListAsync();
        }
        public ActionResult OnPostCreateNewStudent()
        {
            return RedirectToPage("./Scaff_Form");
        }
    }
}