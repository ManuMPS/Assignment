using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Employee.Core.Data;

namespace Employee.Data.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employeee>
    {
        public EmployeeMap()
        {
            HasKey(t => t.ID);
            Property(t => t.EmpName).IsRequired();
            Property(t => t.EmpCode).IsRequired();
            Property(t => t.Age).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            ToTable("Employeee");
        }
    }
}
