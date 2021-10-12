using Demo.DataAccess.src.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.src
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=DemoConnection")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Function> Functions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //不使用modelBuilder.Configurations.AddFromAssembly方法则需要逐个添加,如果数量多的话比较麻烦
            //modelBuilder.Configurations.Add(new OneToMany.Map.ProductMap());
            //此方法可以将当前程序集下所有继承了ComplexTypeConfiguration、EntityTypeConfiguration类型的类添加到注册器
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
