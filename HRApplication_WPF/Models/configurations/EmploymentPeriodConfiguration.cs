using HRApplication_WPF.Model.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Configurations
{
    public class EmploymentPeriodConfiguration : EntityTypeConfiguration<EmploymentPeriod>
    {
        public EmploymentPeriodConfiguration()
        {
            ToTable("dbo.EmploymentPeriods");
            
            HasKey(x => x.Id);

            Property(x => x.EmployeeId)
                .IsRequired();

            Property(x=>x.EmploymentDate) 
                .IsRequired();

            Property(x => x.DismissalDate)
                .IsRequired();


        }
    }
}
