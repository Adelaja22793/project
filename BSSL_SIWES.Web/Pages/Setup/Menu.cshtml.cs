using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Menu;


namespace BSSL_SIWES.Web
{
    public class MenuModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;

        public MenuModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Menu> Menus { get; set; }
        [BindProperty]
        public SiwesData.Menu.Menu Menu { get; set; }

        public async Task OnGetAsync()
        {
            Menus = await _context.Menu.ToListAsync();
            if (Menus !=null)
            {

            }
        }


        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Menu.Add(Menu);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}