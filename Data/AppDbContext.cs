using Microsoft.EntityFrameworkCore;
using Capstone.Models;

namespace Capstone.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // We provide the models through the DbSet<'model name'> fields
        public DbSet<Login> Logins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Performance> Performances {get; set; }
        public DbSet<LeaveType> LeaveTypes {get; set; }
        public DbSet<Holiday> Holidays {get; set; }
        public DbSet<ErrorLog> ErrorLogs {get; set; }
        public DbSet<Goals> Goals { get; set; }

        // We have to override the default behavior to ensure the foreign key constraint is established.
        // If we do not do this then the columns will still be create but the constraints will not be enforced
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Settings for the "1 Employee to 1 Login" relationship*/
            modelBuilder.Entity<Employee>()
            .HasOne(em => em.Login)
            .WithOne(lg=> lg.Employee)
            .HasForeignKey<Login>(lg => lg.EmployeeId);

            /* Settings for the "1 Employee to Many LeaveRequest" relationship*/
            modelBuilder.Entity<Employee>()
            .HasMany(em => em.LeaveRequests)
            .WithOne(lr => lr.Employee)
            .HasForeignKey(lr => lr.EmployeeId);

            /* Settings for the "1 Employee to Many Performance" relationship*/
            modelBuilder.Entity<Employee>()
            .HasMany(em => em.Performances)
            .WithOne(pr => pr.Employee)
            .HasForeignKey(pr => pr.EmployeeId);

            /* Settings for the "1 Manger to Many Employee" relationship*/
            modelBuilder.Entity<Manager>()
            .HasMany(mg => mg.Employees)
            .WithOne(em => em.Manager)
            .HasForeignKey(em => em.ManagerId);      

            /* Settings for the "1 Performance to Many Goals" relationship*/
            modelBuilder.Entity<Performance>()
            .HasMany(pr => pr.Goals)
            .WithOne(gl => gl.Performance)
            .HasForeignKey(gl => gl.PerformanceId); 

            /* Setting for Primary Key on Goals Table*/ 
            modelBuilder.Entity<Goals>()
            .HasKey(gl=> gl.GoalId);

            /* Setting for Primary Key on LeaveType Table*/ 
            modelBuilder.Entity<LeaveRequest>()
            .HasKey(lr=> lr.LeaveId);
            
            /* Setting for Primary Key on LeaveType Table*/ 
            modelBuilder.Entity<LeaveType>()
            .HasKey(lt=> lt.LeaveTypeId);

            /* Setting for Primary Key on Holiday Table*/ 
            modelBuilder.Entity<Holiday>()
            .HasKey(hd=> hd.HolidayId);

             /* Setting for Primary Key on ErrorLog Table*/ 
            modelBuilder.Entity<ErrorLog>()
            .HasKey(er=> er.ErrorId);
        }
    }
}