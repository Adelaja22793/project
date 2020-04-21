using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SiwesData;
using SiwesData.Menu;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class SeedRole
    {
        private ApplicationDbContext _context;
        private readonly RoleManager<RoleTb> _roleManager;
        private readonly UserManager<AppUserTab> _userManager;
        public SeedRole(ApplicationDbContext context, RoleManager<RoleTb> roleManager,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public List<int> submenulis { get; set; }
        public MenuAccess menuAccess {  get; set; }
        public async void SeedRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);


            if (!_context.Roles.Any(r => r.Name == ConstantRole.Cordinator))
            {
                var role = new RoleTb();
                role.Name = ConstantRole.Cordinator.ToString().Trim();
                role.RoleId = "CORD001" ;
                await _roleManager.CreateAsync(role);
            }

            if (!_context.Roles.Any(r => r.Name == ConstantRole.Employer))
            {
                var role = new RoleTb();
                role.Name = ConstantRole.Employer.ToString().Trim();
                role.RoleId = "EMP001";
                await _roleManager.CreateAsync(role);
            }

            if (!_context.Roles.Any(r => r.Name == ConstantRole.Student))
            {
                var role = new RoleTb();
                role.Name = ConstantRole.Student.ToString().Trim();
                role.RoleId = "STD01";
                await _roleManager.CreateAsync(role);
            }
            if (!_context.Roles.Any(r => r.Name == ConstantRole.Admin))
            {
                var role = new RoleTb();
                role.Name = ConstantRole.Admin.ToString().Trim();
                role.RoleId = "Admin";
                await _roleManager.CreateAsync(role);
            }
            if (!_context.Roles.Any(r => r.Name == ConstantRole.SchSuper))
            {
                var role = new RoleTb();
                role.Name = ConstantRole.SchSuper.ToString().Trim();
                role.RoleId = "SchSuper";
                await _roleManager.CreateAsync(role);
            }
            var getadmin = await _userManager.FindByEmailAsync("admin@bssl.com.ng");
            if (getadmin == null)
            {
                var userd = new AppUserTab
                {
                    Email = "admin@bssl.com.ng",
                    UserName = "Admin",
                    RealName = "Bssl Administrator"
                };
                await _userManager.CreateAsync(userd, "Oj5!%hs17");
                await _userManager.AddToRoleAsync(userd, SiwesData.ConstantRole.Admin);
            
            }

          //  var adminroleid = await _roleManager.FindByNameAsync("Admin");
          //  var submenulist =  _context.SubMenu.ToList();
          //  var saveadminmenu = new MenuAccess() ;

          ////  saveadminmenu.RoleId = adminroleid.Id;
          //  using (var saved = new MenuAccess())
          //  {
          //      foreach (var dd in submenulist)
          //      {
          //          saved.RoleId = adminroleid.Id;
          //          saved.Id = dd.Id;
          //      }
          //      _context.MenuAccess.Add(saved);
          //      await _context.SaveChangesAsync();

          //  }
          //  foreach(var ddd in submenulist)
          //  {
          //      MenuAccess savemenu = new MenuAccess(
          //      {
          //          savemenu.RoleId = adminroleid.Id,
          //          savemenu.Id = ddd.Id,

          //      });
          //  }
          //  using (var ctx = new ApplicationDbContext() )
          //  {
          //      foreach (var value in saveadminmenu)
          //      {
          //          value.Username = user;
          //          value.Changed = DateTime.Now;
          //          ctx.UOSChangeLog.Add(value);
          //      }
          //      ctx.SaveChanges();
          //      return true;
          //  }
            //}
            //    foreach (var dd in submenulist)
            //    {

            //        saveadminmenu.RoleId = adminroleid.Id;
            //        saveadminmenu.SubMenuId = dd.Id;
            //        _context.MenuAccess.Add(saveadminmenu);
            //        await _context.SaveChangesAsync();

            //    }

            //using (var ctx = new MenuAccess)
            //{
            //    saveadminmenu(u => { u. = user; u.Changed = DateTime.Now; });
            //    var test = ctx.UOSChangeLog.AddRange(values);
            //    ctx.SaveChanges();
            //    return true;
            //}

            //using (menuAccess = new MenuAccess())
            //{
            //    foreach (var dd in saveadminmenu)
            //    {
            //        roleid = user;
            //        value.Changed = DateTime.Now;
            //        ctx.UOSChangeLog.Add(value);
            //    }
            //    ctx.SaveChanges();
            //    return true;
            //}
            //var newMonthlyAssessment = new MenuAccess
            //{
            //    RoleId = adminroleid.Id,
            //    SubMenuId = submenulist,
            //};



        }
    }
}
