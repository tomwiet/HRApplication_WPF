using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Model.Domains
{
    public class EmploymentPeriod
    {
        public int EmployeeId {  get; set; }    
        public DateTime EmploymentDate { get; set; }
        public DateTime DismissalDate { get; set; }

        public Employee Employee { get; set; }

    }
}
