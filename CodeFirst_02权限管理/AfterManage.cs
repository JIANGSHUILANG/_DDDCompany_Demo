using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_02权限管理
{
    //public class AfterManage
    //{
    //static void Main()
    //{
    //    using (AfterManageContext ef = new AfterManageContext())
    //    {
    //        //ActionInfo action = new ActionInfo()
    //        //{
    //        //    ActionInfoName = "DeleteUserInfo",
    //        //    Url = "/UserInfo/DeleteUserInfo",
    //        //    HttpMethod = 1,
    //        //    DelFalg = 1,
    //        //    SubTime = DateTime.Now,
    //        //    Remark="只有超级管理员才有这个权限 !",
    //        //    IsMenu = false
    //        //};

    //        //ef.ActionInfo.Add(action)

    //        var userinfo= ef.UserInfo.Where(c=>true).FirstOrDefault();

    //        //ef.SaveChanges();
    //    }
    //    Console.ReadKey();
    //}
    //}

    #region Code Entites

    #region IAggregateRoot

    public interface IEntity { }

    public interface IAggregateRoot : IEntity { }

    public abstract class AggregateRoot : IAggregateRoot { }
    
    #endregion


    public partial class UserInfo : AggregateRoot
    {
        public UserInfo()
        {
            this.Roles = new List<Role>();
            this.ActionInfos = new List<ActionInfo>();
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public System.DateTime RegTime { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<ActionInfo> ActionInfos { get; set; }
    }

    public partial class Role : AggregateRoot
    {
        public Role()
        {
            this.ActionInfos = new List<ActionInfo>();
            this.UserInfos = new List<UserInfo>();
        }
        public int ID { get; set; }
        public string RoleName { get; set; }
        public short DelFlag { get; set; }
        public short RoleType { get; set; }
        public System.DateTime SubTime { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<ActionInfo> ActionInfos { get; set; }

    }

    public partial class ActionInfo : AggregateRoot
    {
        public ActionInfo()
        {
            this.UserInfos = new List<UserInfo>();
            this.Roles = new List<Role>();
        }
        public int ID { get; set; }
        public string ActionInfoName { get; set; }
        public string Url { get; set; }
        public short HttpMethod { get; set; }
        public string Remark { get; set; }
        public short DelFalg { get; set; }
        public System.DateTime SubTime { get; set; }
        public bool IsMenu { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }

    public class Menu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public short DelFlag { get; set; }
        public System.DateTime SubTime { get; set; }

        public virtual Role Role { get; set; }
    }



    public class ActionGroup
    {
        public ActionGroup()
        {
            this.ActionInfo = new HashSet<ActionInfo>();
            this.Role = new HashSet<Role>();
        }

        public int ID { get; set; }
        public string GroupName { get; set; }
        public short GroupType { get; set; }
        public string DelFlag { get; set; }
        public int Sort { get; set; }

        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        public virtual ICollection<Role> Role { get; set; }
    }

    public class Setting
    {

    }


    #endregion

    #region Entites Configuration

    public partial class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.UserName).HasMaxLength(50).IsRequired();
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.UserName).HasColumnName("UserName");
            this.Property(c => c.UserPass).HasColumnName("UserPass");
            this.Property(c => c.RegTime).HasColumnName("RegTime");
            this.Property(c => c.Email).HasColumnName("Email");


            this.HasMany(c => c.Roles)
                .WithMany(c => c.UserInfos);

            this.HasMany(c => c.ActionInfos)
                .WithMany(c => c.UserInfos);

            this.ToTable("UserInfo");
        }
    }

    public partial class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.RoleName).HasMaxLength(50).IsRequired();
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.DelFlag).HasColumnName("DelFlag");
            this.Property(c => c.RoleType).HasColumnName("RoleType");
            this.Property(c => c.SubTime).HasColumnName("SubTime");
            this.Property(c => c.Remark).HasColumnName("Remark");


            this.HasMany(c => c.UserInfos)
                .WithMany(c => c.Roles);

            this.HasMany(c => c.ActionInfos)
                .WithMany(c => c.Roles);

            this.ToTable("Role");
        }
    }

    public partial class ActionInfoConfiguration : EntityTypeConfiguration<ActionInfo>
    {
        public ActionInfoConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.ActionInfoName).HasMaxLength(50).IsRequired();
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.ActionInfoName).HasColumnName("ActionInfoName");
            this.Property(c => c.Url).HasColumnName("Url");
            this.Property(c => c.HttpMethod).HasColumnName("HttpMethod");
            this.Property(c => c.Remark).HasColumnName("Remark");

            this.Property(c => c.DelFalg).HasColumnName("DelFalg");
            this.Property(c => c.SubTime).HasColumnName("SubTime");
            this.Property(c => c.IsMenu).HasColumnName("IsMenu");



            this.HasMany(c => c.UserInfos)
                .WithMany(c => c.ActionInfos);

            this.HasMany(c => c.Roles)
                .WithMany(c => c.ActionInfos);

            this.ToTable("ActionInfo");
        }
    }

    #endregion

    #region EntityFramework

    public class AfterManageContext : DbContext
    {
        public AfterManageContext()
            : base("name=AfterManageContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AfterManageContext>());
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ActionInfo> ActionInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除表名复数的契约
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                .Add(new UserInfoConfiguration())
                .Add(new RoleConfiguration())
                .Add(new ActionInfoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    #endregion
}


//1	超级管理员	1	0	2015-11-23 00:00:00.000	所有功能都能操作
//2	中级管理员	1	1	2015-11-23 00:00:00.000	有些特敏感权限不可用
//3	普通管理员	1	2	2015-11-23 00:00:00.000	普通增删改查
//4	会员	    1   3	2015-11-23 00:00:00.000	查增改没有操作功能
//5	员工	    1   3	2015-11-23 00:00:00.000	查询功能


//1	江水浪	123456	2015-11-23 00:00:00.000	404782666@qq.com