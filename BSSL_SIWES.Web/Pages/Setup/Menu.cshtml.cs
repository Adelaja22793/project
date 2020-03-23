using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BSSL_SIWES.Web
{
    public class MenuModel : PageModel
    {
        private readonly SiwesData.Data.ApplicationDbContext _context;

        public MenuModel(SiwesData.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SiwesData.Data.Menu.Menu> Menus { get; set; }
        [BindProperty]
        public SiwesData.Data.Menu.Menu Menu { get; set; }

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