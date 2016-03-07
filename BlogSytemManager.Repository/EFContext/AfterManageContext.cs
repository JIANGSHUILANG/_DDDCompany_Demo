using BlogSytemManager.Repository.Entity_Configuration;
using BolgSytemManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.Repository.EFContext
{
    #region EntityFramework

    public class AfterManageContext : DbContext
    {
        public AfterManageContext()
            : base("name=AfterManageContext")
        {

            //this.Configuration.ProxyCreationEnabled = false; //取消默认生成的代理类，就是不要导航属性
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.AutoDetectChangesEnabled = false;

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AfterManageContext>());
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ActionInfo> ActionInfo { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuChilden> MenuChilden { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Blog> Blog { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除表名复数的契约
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                .Add(new UserInfoConfiguration())
                .Add(new RoleConfiguration())
                .Add(new ActionInfoConfiguration())
                .Add(new MenuChildenConfiguration())
                .Add(new MenuConfiguration())
                .Add(new PermissionConfiguration())
                .Add(new BlogConfiguration())
                .Add(new CommentConfiguration());

            //EF 6.0 + 版本支持
            //modelBuilder.Entity<Post>().MapToStoredProcedures();--往数据库中映射存储过程

            base.OnModelCreating(modelBuilder);
        }

    }

    #endregion

    //它总是会在首次在应用程序域中使用上下文时，重新创建数据库并选择用数据重新设置数据库的种子
    public class USMDBInitializer : DropCreateDatabaseAlways<AfterManageContext>
    {
        protected override void Seed(AfterManageContext context)
        {
            UserInfo userinfo = new UserInfo();
            userinfo.Email = "Admin";
            userinfo.UserPass = "123456";
            context.UserInfo.Add(userinfo);

            Menu menu = new Menu();
            menu.MenuName ="菜单管理";


            context.SaveChanges();
            base.Seed(context);
        }
    }
}
