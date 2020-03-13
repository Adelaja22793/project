﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Menu;

namespace BSSL_SIWES.Web
{
    public class SubMenuModel : PageModel
    {

        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public SubMenuModel(SiwesData.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Menu> MenuList { get; set; }
        public List<SubMenu> SubMenus { get; set; }
        public IList<SubMenu> MainSubMenu { get; set; }
        [BindProperty]
        public SubMenu SubMenu { get; set; }
        public string SubMenuName { get; set; }
        public IList<Menu> Menus { get; set; }
        public string Message { get; set; }
        public string PageURL { get; set; }
        public async Task OnGet(string pageURL = null)
        {
            
            pageURL = pageURL ?? Url.Content("~/");
            MenuList = _context.Menu.ToList();

            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name");
            MainSubMenu = await _context.SubMenu
                .Include(s => s.Menu).ToListAsync();
            PageURL = pageURL;
            // return Page();
        }
        //public HttpResponseMessage GetMessage([FromBody] string MenuName)
        //{
        //    var Subcat =  _context.Menu
        //        .Where(x => x.Name.Contains(MenuName)).ToList();

        //    return Subcat;
        //}
    }
}