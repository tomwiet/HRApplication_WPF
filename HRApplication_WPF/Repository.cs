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

        public void UpdateEmployee(EmployeeWrapper employee)
        {
            using( var context = new ApplicationDbContext())
            {
               var employeeToUpdate = context.Employees.Find(employee.Id);
               var employeeDb = employee.ToDao();

               employeeToUpdate.FirsName = employeeDb.FirsName;
               employeeToUpdate.LastName = employeeDb.LastName;
               employeeToUpdate.Earnings = employeeDb.Earnings;

               var employmentPeriodToUpdate = context.EmploymentPeriods.Find(employee.EmploymentPeriodId);
               var employmentPeriodDb = employee.ToEmployementPeriodDao();

               employmentPeriodToUpdate.DismissalDate = employmentPeriodDb.DismissalDate;
               employmentPeriodToUpdate.EmploymentDate = employmentPeriodDb.EmploymentDate;

                context.SaveChanges();
            }
            
        }

        public void DismissEmployee(object employmentPeriodId)
        {
            using( var context = new ApplicationDbContext())
            {
                var employmentPeriodToUpdate = context.EmploymentPeriods.Find(employmentPeriodId);
                employmentPeriodToUpdate.DismissalDate = DateTime.Now;
                context.SaveChanges();
            }
           
        }

        public List<EmployeeWrapper> GetActualEmployees()
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees
                    .Include(x => x.EmploymentPeriods)
                    .AsQueryable();


                return employees
                    .ToList()
                    .Select(x => x.ToWrapper())
                    .Where(y=>y.DismissDate==null)
                    .ToList();
            }
        }

        public List<EmployeeWrapper> GetDismissedEmployees()
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees
                    .Include(x => x.EmploymentPeriods)
                    .AsQueryable();


                return employees
                    .ToList()
                    .Select(x => x.ToWrapper())
                    .Where(y => y.DismissDate != null)
                    .ToList();
            }
        }
    }
}
