using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Model.Domains
{
    public class Employee
    {
        public Employee()
        { 
            EmploymentPeriods = new Collection<EmploymentPeriod>();
        }
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName {  get; set; }
        public decimal Earnings {  get; set; }
        
        public ICollection<EmploymentPeriod> EmploymentPeriods { get; set; }

        
    }
}
