using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BSSL_SIWES.Web
{
    public class MenuModel : PageModel
    {
        private readonly SiwesData.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public MenuModel(SiwesData.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<SiwesData.Data.Menu.Menu> Menus { get; set; }
        [BindProperty]
        public SiwesData.Data.Menu.Menu Menu { get; set; }
        public string MenuName { get; set; }
        public string Message { get; set; }
        public async Task OnGetAsync()
        {
            //Menus = _context.Menu.to 
            Menus = await _context.Menu.ToListAsync();
            if (Menus != null)
            {
                Message = "No Menu Has Been Setup, Please Click On Add Menu to Add";
            }
        }
    }
}