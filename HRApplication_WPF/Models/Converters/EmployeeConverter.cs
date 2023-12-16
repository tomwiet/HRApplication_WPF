using HRApplication_WPF.Model.Domains;
using HRApplication_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                Id = model.Id,
                FirstName = model.FirsName, 
                LastName = model.FirsName,
                Earnings = model.Earnings,
                EmploymentPeriod = new EmploymentPeriodWrapper
                {
                    EmploymentDate = model.EmploymentPeriods
                    .Where(x=>x.EmployeeId == model.Id)
                    .Select(y=>y.EmploymentDate)
                    .First(),
                    DismissDate = model.EmploymentPeriods
                    .Where(x => x.EmployeeId == model.Id)
                    .Select(y => y.DismissalDate)
                    .First(),


                }
            };
        }

    }
}
