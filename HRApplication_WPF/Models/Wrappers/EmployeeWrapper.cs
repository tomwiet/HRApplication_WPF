using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Wrappers
{
    public class EmployeeWrapper
    {
        public int Id { get; set; }
        
        public int EmploymentPeriodId { get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public decimal Earnings {  get; set; }
        public DateTime EmploymentDate {  get; set; }
        public DateTime? DismissDate {  get; set; }
	}
}
