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
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class AssignMenuModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;

        public AssignMenuModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<RoleTb> RoleTb { get; set; }
        public RoleTb RolesTb { get; set; }
        public List<SelectListItem> options { get; set; }
        public async Task OnGetAsync()
        {
            RoleTb = await _context.RoleTb.ToListAsync();
            MenuAccesses = await _context.MenuAccess.Include(s => s.RoleTb).ToListAsync();
            ViewData["RoleId"] = new SelectList(_context.RoleTb.Where(m => m.RoleId.ToUpper() != "STD01"), "Id", "Name");
            SubMenus = await _context.SubMenu.Include(b => b.Menu).Where(n => n.MenuId == n.Menu.Id).ToListAsync();
           
            options = await _context.RoleTb.Select(m => new SelectListItem
            {
                Value = m.RoleId,
                Text = m.Name
            }).ToListAsync();




        }
        public List<MenuAccess> MenuAccesses { get; set; }
        public SubMenu SubMenu { get; set; }

   
        [BindProperty]
        public MenuAccess MenuAccess { get; set; }

        public IList<SubMenu> SubMenus { get; set; }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.MenuAccess.Add(MenuAccess);
        //    await _context.SaveChangesAsync();

        //    return Page();
        //}
    }
}
