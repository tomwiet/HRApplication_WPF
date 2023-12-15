using HRApplication_WPF.Model.Domains;
using HRApplication_WPF.Models.Configurations;
using System;
using System.Data.Entity;
using System.Linq;

namespace HRApplication_WPF
{
    public class ApplicationDbContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HRApplication_WPF.ApplicationDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDbContext' 
        // connection string in the application configuration file.
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }  
        public DbSet<EmploymentPeriod>EmploymentPeriods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmploymentPeriodConfiguration());
        }
    }

  
}