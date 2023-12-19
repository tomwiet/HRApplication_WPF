using HRApplication_WPF.Models.Converters;
using HRApplication_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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

        public void AddEmployee(EmployeeWrapper employeeWrapper)
        {
            using( var context = new ApplicationDbContext())
            {
                var employee = employeeWrapper.ToDao();
                context.Employees.Add(employee);

                var employmentPeriod = employeeWrapper.ToEmployementPeriodDao();
                context.EmploymentPeriods.Add(employmentPeriod);

                context.SaveChanges();

            }
        }

        internal void UpdateEmployee(EmployeeWrapper employee)
        {
            using( var context = new ApplicationDbContext())
            {
               
            }
            
        }

        internal void DismissEmployee(object employmentPeriodId)
        {
            using( var context = new ApplicationDbContext())
            {
                var employmentPeriodToUpdate = context.EmploymentPeriods.Find(employmentPeriodId);
                employmentPeriodToUpdate.DismissalDate = DateTime.Now;
                context.SaveChanges();
            }
           
        }
    }
}
