using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Employee.Core.Data;


namespace Employee.Data.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            HasKey(t => t.ID);
            Property(t => t.Address1).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            Property(t => t.Address2).HasMaxLength(100).HasColumnType("nvarchar");
            Property(t => t.Pincode).HasColumnType("nvarchar");
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            ToTable("Address");
            HasRequired(t => t.Employee).WithRequiredDependent(u => u.Address);
        }
    }
}
