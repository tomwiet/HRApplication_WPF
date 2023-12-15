using HRApplication_WPF.Model.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Configurations
{
    internal class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("dbo.Employes");
            HasKey(x => x.Id);

            Property(x => x.FirsName)
                    .HasMaxLength(100)
                    .IsRequired();

            Property(x => x.LastName)
                    .HasMaxLength(100)
                    .IsRequired();
        }

    }
}
