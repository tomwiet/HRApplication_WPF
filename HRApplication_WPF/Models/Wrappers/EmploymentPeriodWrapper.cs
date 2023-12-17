using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Wrappers
{
    public class EmploymentPeriodWrapper
    {
        public int Id {  get; set; }
        public int EmployeeId {  get; set; }
        public DateTime EmploymentDate {  get; set; }
        public DateTime? DismissDate {  get; set; }

    }
}
