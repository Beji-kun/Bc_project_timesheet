using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<TimesheetUser> TimesheetUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-many, User-Role
            modelBuilder.Entity<User>()
                .HasOne<Role>(e => e.Role)
                .WithMany(d => d.Users)
                .HasForeignKey(e => e.RoleID);
            //many-many, User-Project
            modelBuilder.Entity<UserProject>().HasKey(t => new { t.UserID, t.ProjectID });
            modelBuilder.Entity<UserProject>()
            .HasOne(t => t.Users)
            .WithMany(t => t.UserProjects)
            .HasForeignKey(t => t.UserID);
            modelBuilder.Entity<UserProject>()
                        .HasOne(t => t.Projects)
                        .WithMany(t => t.UserProjects)
                        .HasForeignKey(t => t.ProjectID);

            //many-many TimeSheet-User
            modelBuilder.Entity<TimesheetUser>().HasKey(t => new { t.UserID, t.TimeSheetID });
            modelBuilder.Entity<TimesheetUser>()
                .HasOne(t => t.Users)
                .WithMany(t => t.TimesheetUsers)
                .HasForeignKey(t => t.UserID);
            modelBuilder.Entity<TimesheetUser>()
                .HasOne(t => t.Timesheets)
                .WithMany(t => t.TimesheetUsers)
                .HasForeignKey(t => t.TimeSheetID);

            //one-many Project-Company
            modelBuilder.Entity<Project>()
                .HasOne<Company>(e => e.Company)
                .WithMany(d => d.Projects)
                .HasForeignKey(e => e.CompanyID);

            base.OnModelCreating(modelBuilder);

        }
    }
}
