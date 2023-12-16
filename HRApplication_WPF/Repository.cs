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

                return new List<EmployeeWrapper>();
            }
        
           
        }

       

    }
}
