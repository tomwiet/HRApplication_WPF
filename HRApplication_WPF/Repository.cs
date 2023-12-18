using HRApplication_WPF.Models.Converters;
using HRApplication_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF
{
    public class Repository
    {
        public List<EmployeeWrapper> GetEmployees() 
        { 
            using(var context = new ApplicationDbContext())
            {
                var employees = context.Employees
                    .Include(x=>x.EmploymentPeriods)
                    .AsQueryable();

                return employees
                    .ToList()
                    .Select(x=>x.ToWrapper())
                    .ToList();
            }
         
        }

        public void AddEmployee(EmployeeWrapper employee)
        {
            using( var context = new ApplicationDbContext())
            {
                var employeeDb = employee.ToDao();
                context.Employees.Add(employeeDb);

                var employmentPeriod = employee.ToEmployementPeriodDao();
                context.EmploymentPeriods.Add(employmentPeriod);

                context.SaveChanges();

            }
        }

        internal void UpdateEmployee(EmployeeWrapper employee)
        {
            using (var context = new ApplicationDbContext())
            {
                var employeDb = employee.ToDao();
                var employmentPeriodsDb = employee.ToEmployementPeriodDao(); 
                var employeeToUpdate = context.Employees.Find(employee.Id);

                employeeToUpdate.FirsName = employeDb.FirsName;
                employeeToUpdate.LastName = employeDb.LastName;
                employeeToUpdate.Earnings = employeDb.Earnings;

                var employmentPeriodToUpdate = context.EmploymentPeriods.Find(employee.EmploymentPeriodId);

                employmentPeriodToUpdate.EmploymentDate = employmentPeriodsDb.EmploymentDate;
                employmentPeriodToUpdate.DismissalDate = employmentPeriodsDb.DismissalDate;

                context.SaveChanges();

            }
                
            
        }
    }
}
