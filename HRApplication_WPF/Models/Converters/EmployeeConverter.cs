using HRApplication_WPF.Model.Domains;
using HRApplication_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Converters
{
    public static class EmployeeConverter 
    { 
    
        public static Employee ToDao(this EmployeeWrapper model)
        {
           
            return new Employee
            {
                Id = model.Id,
                FirsName = model.FirstName,
                LastName = model.LastName,
                Earnings = model.Earnings,
                
            };
        }

        public static EmploymentPeriod ToEmployementPeriodDao(this EmployeeWrapper model) 
        {
            return new EmploymentPeriod
            { 
                EmployeeId = model.Id,
                EmploymentDate = model.EmploymentDate,
                DismissalDate = model.DismissDate
            };
        
        }
        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                Id = model.Id,
                EmploymentPeriodId = model.EmploymentPeriods
                                        .Where(x=>x.EmployeeId==model.Id)
                                        .Select(y=>y.Id)
                                        .First(),
                FirstName = model.FirsName,
                LastName = model.LastName,
                Earnings = model.Earnings,
                EmploymentDate = model.EmploymentPeriods
                                        .Where(x => x.EmployeeId == model.Id)
                                        .Select(y => y.EmploymentDate)
                                        .First(),
                DismissDate = model.EmploymentPeriods
                                        .Where(x => x.EmployeeId == model.Id)
                                        .Select(y=>y.DismissalDate)
                                        .First(),   
            };
        }

    }
}
