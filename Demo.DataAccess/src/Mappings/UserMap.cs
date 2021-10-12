using Demo.DataAccess.src.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.src.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("my_demo_user");
            this.HasKey(x => x.UId);
            this.Property(x => x.Name).HasMaxLength(50);
            this.Property(x => x.Age);
            
            //this.HasRequired(x => x.Roles).WithMany(y => y.UserList).HasForeignKey(x => x.RId);

            //this.HasOptional(x => x.Roles).WithMany(y => y.UserList);

            //.HasForeignKey(k => k.RId).WillCascadeOnDelete(false);
        }
    }
}
