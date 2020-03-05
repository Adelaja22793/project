using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SIWES_BSSL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
    //    public DbSet<Setup.AgencySuperSetup> AgencySuperSetup { get; set; }
    //    public DbSet<Setup.CourseGrpSetup> CourseGrpSetup { get; set; }
    //    public DbSet<Setup.Courses> Courses { get; set; }
    //    public DbSet<Setup.InstCarryCap> InstCarryCap { get; set; }
    //    public DbSet<Setup.InstCatSetup> InstCatSetup { get; set; }
    //    public DbSet<Setup.Institution> Institution { get; set; }
    //    public DbSet<Setup.InstLevelStudy> InstLevelStudy { get; set; }
    //    public DbSet<Setup.InstTypeSetup> InstTypeSetup { get; set; }
    //    public DbSet<Setup.PolicyTb> PolicyTb { get; set; }

        public DbSet<Menu.Menu> Menu { get; set; }
        //public DbSet<Menu.MenuAccess> MenuAccess { get; set; }
        public DbSet<Menu.SubMenu> SubMenu { get; set; }
        public DbSet<Menu.MessageTb> MessageTb { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
