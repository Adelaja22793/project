using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SiwesData;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class SeedRole
    {
        private ApplicationDbContext _context;
        private readonly RoleManager<RoleTb> _roleManager;
        public SeedRole(ApplicationDbContext context, RoleManager<RoleTb> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

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
           
        }
    }
}
