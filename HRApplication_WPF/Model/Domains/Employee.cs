using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Model.Domains
{
    public class Employee
    {
        public Employee()
        { 
            EmploymentPeriod = new EmploymentPeriod();
        }
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName {  get; set; }
        public decimal Earnings {  get; set; }
        
        public EmploymentPeriod EmploymentPeriod { get; set; }

        
    }
}
