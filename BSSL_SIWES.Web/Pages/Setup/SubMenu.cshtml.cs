using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Menu;

namespace BSSL_SIWES.Web
{
    public class SubmenuModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;

        public SubmenuModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SubMenu> SubMenus { get; set; }
        [BindProperty]
        public SubMenu SubMenu { get; set; }

        public async Task OnGetAsync()
        {   
            
            SubMenus = await _context.SubMenu.Include(s => s.Menu).ToListAsync();
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name");

        }
        //[BindProperty]
        //public SubMenu SubMenu { get; set; }
        

    }
}