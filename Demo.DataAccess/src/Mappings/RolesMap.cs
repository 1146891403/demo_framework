using Demo.DataAccess.src.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.src.Mappings
{
    public class RolesMap : EntityTypeConfiguration<Roles>
    {
        public RolesMap()
        {
            ToTable("my_demo_roles");
            this.HasKey(x => x.RId);
            this.Property(x => x.RName).HasMaxLength(110);

            this.HasMany(r => r.UserList).WithRequired(u => u.Roles).HasForeignKey(u => u.RId).WillCascadeOnDelete();
        }
    }
}
