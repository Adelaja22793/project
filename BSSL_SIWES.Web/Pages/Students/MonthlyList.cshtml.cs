﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Students;

namespace BSSL_SIWES.Web.Pages.Students
{
    public class MonthlyListModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly SignInManager<AppUserTab> _signInManager;

        public MonthlyListModel(SiwesData.ApplicationDbContext context, SignInManager<AppUserTab> signInManager,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IList<MonthlyAssessment> MonthlyAssessments { get; set; }
        public int StudentId { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //this gets the id from the AspNetUsers table
            var loginUser = _userManager.GetUserId(User);
            //var userEmail = await _userManager.GetUserNameAsync(loginUser);
            var userEmail = _userManager.GetUserName(User);

            StudentId = await _context.StudentSetUps.Where(x => x.Email == userEmail).Select(x => x.Id).FirstOrDefaultAsync();

            MonthlyAssessments = await _context.MonthlyAssessments
                           .Where(x => x.StudentSetUpId == id).ToListAsync();

            return Page();
        }
    }
}