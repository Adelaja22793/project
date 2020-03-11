using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Data;

namespace BSSL_SIWES.Web
{
    public class SupervisoryAgencyModel : PageModel
    {
        private readonly SiwesData.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public SupervisoryAgencyModel(SiwesData.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void OnGet()
        {

        }
    }
}