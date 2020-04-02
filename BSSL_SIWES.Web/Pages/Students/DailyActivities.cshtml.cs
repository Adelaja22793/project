﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;

namespace BSSL_SIWES.Web
{
    public class DailyActivitiesModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DailyActivitiesModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<SelectListItem> SelectMonth { get; set; }
        public DailyActivities DailyActivities { get; set; }
        public DailyActivitiesList DailyActivitiesList { get; set; }
        public Scaf Scaf { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            int id = 19;
            SelectMonth = new List<SelectListItem>
            {
                new SelectListItem { Value = "January", Text = "January" },
                new SelectListItem { Value = "February", Text = "February" },
                new SelectListItem { Value = "March", Text = "March" },
                new SelectListItem { Value = "April", Text = "April" },
                new SelectListItem { Value = "May", Text = "May" },
                new SelectListItem { Value = "June", Text = "June" },
                new SelectListItem { Value = "July", Text = "July" },
                new SelectListItem { Value = "August", Text = "August" },
                new SelectListItem { Value = "September", Text = "September" },
                new SelectListItem { Value = "October", Text = "October" },
                new SelectListItem { Value = "November", Text = "November" },
                new SelectListItem { Value = "December", Text = "December" },
            };

            Scaf = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
                .Where(x => x.StudentSetUpId == x.StudentSetUp.Id && x.EmployerSupervisorId == x.EmployerSupervisor.Id
                && x.StudentSetUpId == id).SingleOrDefaultAsync();
            //DailyActivitiesList = await _context.DailyActivitiesLists.Include(v => v.DailyActivities)
            //        .SingleOrDefaultAsync(x => x.DailyActivitiesId == x.DailyActivities.Id && x.DailyActivities.StudentSetUpId == id);
            //var DayValue = DailyActivitiesList.DayValue;
            //StudentName = StudentSetUp.Surname + ' ' + StudentSetUp.OtherNames;
            if (Scaf == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}