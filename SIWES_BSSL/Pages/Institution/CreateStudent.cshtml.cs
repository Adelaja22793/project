using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SIWES_BSSL
{
    public class CreateStudentModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateStudentModel(SIWES_BSSL.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void OnGet()
        {
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");

            //return Page();
        }
    }
}