using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Wrappers
{
    public class EmployeeWrapper
    {
        public EmployeeWrapper()
        {
                EmploymentPeriod = new EmploymentPeriodWrapper();
        }

        public int Id;
        public string FirstName;
        public string LastName;
        public decimal Earnings;
        public EmploymentPeriodWrapper EmploymentPeriod;

	}
}
