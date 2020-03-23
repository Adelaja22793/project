﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SiwesData
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Setup.AgencySuperSetup> AgencySuperSetup { get; set; }
        public DbSet<Setup.CourseGrpSetup> CourseGrpSetup { get; set; }
        public DbSet<Setup.Courses> Courses { get; set; }
        public DbSet<Setup.InstCarryCap> InstCarryCap { get; set; }
        public DbSet<Setup.InstCatSetup> InstCatSetup { get; set; }
        public DbSet<Setup.Institution> Institution { get; set; }
        public DbSet<Setup.InstLevelStudy> InstLevelStudy { get; set; }
        public DbSet<Setup.InstTypeSetup> InstTypeSetup { get; set; }
        public DbSet<Setup.PolicyTb> PolicyTb { get; set; }

        public DbSet<Setup.Nationality> Nationalities { get; set; }
        public DbSet<Setup.State> States { get; set; }
        public DbSet<Setup.LGA> LGAs { get; set; }

        public DbSet<Menu.Menu> Menu { get; set; }
        public DbSet<Menu.MenuAccess> MenuAccess { get; set; }
        public DbSet<Menu.SubMenu> SubMenu { get; set; }
        public DbSet<Setup.AreaOffice> AreaOffices { get; set; }
      

        public DbSet<Students.Scaf> Scafs { get; set; }
        public DbSet<Students.StudentSetUp> StudentSetUps { get; set; }

        public DbSet<Employer.EmployerSuperSetup> EmployerSuperSetups { get; set; }
        public DbSet<Employer.EmployerSupervisor> EmployerSupervisors { get; set; }

        public DbSet<Setup.NewCourseRequest> NewCourseRequests { get; set; }

        public DbSet<Setup.InstitutionOfficer> InstitutionOfficers { get; set; }
        public DbSet<Setup.SupervisoryAgency> SupervisoryAgencies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Menu.Menu>().HasIndex(b => b.Name).IsUnique();
            builder.Entity<Setup.Courses>().HasIndex(b => b.Name).IsUnique();
            builder.Entity<Setup.NewCourseRequest>().HasIndex(b => b.Name).IsUnique();
            base.OnModelCreating(builder);
            
        }
    }
}
