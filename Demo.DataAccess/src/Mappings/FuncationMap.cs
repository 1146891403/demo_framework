using Demo.DataAccess.src.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.src.Mappings
{
    public class FuncationMap : EntityTypeConfiguration<Function>
    {
        public FuncationMap()
        {
            this.ToTable("my_demo_funcation");
            this.HasKey(f => f.FunctionId);
            this.Property(f => f.Name).HasMaxLength(200);
            this.Property(f => f.CreateDate).IsRequired();

            this.HasMany(f => f.RolesList)
                .WithMany(r => r.FunctionsList)
                .Map(x =>
                        {
                            x.ToTable("FuncationRoles");//中间表表名
                            x.MapLeftKey("FuncationId");//主表key
                            x.MapRightKey("RolesId");//从表
                        });
        }
    }
}
