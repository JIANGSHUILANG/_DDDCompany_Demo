using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_01配置各种关系
{
    class Test
    {
        static void Main()
        {
            //install-package entityframework.zh-hans -version 6.1.1 (安装Entityframework)

            //当数据库表的结构更改之后，需要对数据库做迁移

            // 工具-->>程序包管理器-->>程序包管理器控制台-->>enable-migrations -force-->>将AutomaticMigrationsEnabled 值改为 true-->>Update-Database -Verbose
            //连接数据库方式_01
            using (CodeFirst_02Context ef = new CodeFirst_02Context())
            {
                //ef.Database.Initialize(true);
                //UserInfo user = new UserInfo() { Name="zhangsan",Address_Id=1};
                //ef.UserInfo.Add(user);
             
                 
                OtherInfo other = new OtherInfo() { Email = "404782@qq.com", Cell ="123456" };
                ef.OtherInfo.Add(other);

                //报错：An error occurred while updating the entries. See the inner exception for details
                //  modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                ef.SaveChanges();
            }


            //连接数据库方式_02
            //var cstr = @"Server=.;Database=CodeFirstTemp_02;Trusted_Connection=true";
            //using (var conn = new SqlConnection(cstr))
            //{
            //    using (var context = new CodeFirst_02Context(conn))
            //    {
            //        UserInfo user = new UserInfo() 
            //        {
            //        Name="zhangsan",
            //        Age=18
            //        };
            //        context.UserInfo.Add(user);
            //        context.SaveChangesAsync();

            //    }
            //}


            Console.ReadKey();
        }
    }

    public class CodeFirst_02Context : DbContext
    {

        public CodeFirst_02Context()
            : base("name=CodeFirst_02Context")
        {
            //  如果我们在在模型改变时，自动重新创建一个新的数据库，就可以用这个方法。在这开发过程中非常有用;
            // 拿到上下文 context：  context.Database.Initialize(true);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CodeFirst_02Context>());

            //如果你想在每次运行时都重新生成数据库就可以用这个方法
            //Database.SetInitializer(new DropCreateDatabaseAlways<CodeFirstContext>());
        }

        //利用DbConnection，DbContext有一个带DbConnection重载的构造函数，说明我们也可以通过DbConnection来定位数据库位置。
        public CodeFirst_02Context(DbConnection connection)
            : base(connection, contextOwnsConnection: false) { }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OtherInfo> OtherInfo { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<UserInfoExtension> UserInfoExtension { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations
                .Add(new UserInfoConfiguration())
                .Add(new AddressConfiguration())
                .Add(new OtherInfoConfiguration())
                .Add(new ProductConfiguration())
                .Add(new OrderConfiguration());

            //对于不需要映射到数据库中的表，我们也可以取消其映射。类头上加：[NotMapped]特性标签
            //或者：
            modelBuilder.Ignore<UserInfoExtension>();

            base.OnModelCreating(modelBuilder);
        }

    }

    [NotMapped]
    public class UserInfoExtension
    {
        public DateTime Brithday { get; set; }
        public string Work { get; set; }
    }

    public class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).HasColumnName("Name");
            this.Property(c => c.Age).HasColumnName("Age");
            this.Property(c => c.OtherInfo_Id).IsOptional().HasColumnName("OtherInfo_Id");
            this.Property(c => c.Address_Id).IsOptional().HasColumnName("Address_Id");

            this.Ignore(c => c.LoginTime);//忽略 LoginTime 字段的映射
            //- Configuring a Required-to-Many Relationship (One-to-Many)

            //配置一对多关系  一个用户包含多个订单   
            this.HasMany(c => c.Orders)
                .WithRequired(c => c.UserInfo)
                .WillCascadeOnDelete(true);//WillCascadeOnDelete(true)级联操作


            this.ToTable("UserInfo");
        }
    }

    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Content).HasColumnName("Content");

            // Configuring a Relationship Where Both Ends Are Required (One-to-One)
            //一个用户肯定有一个地址信息（包含家庭住址、居住地址）
            this.HasRequired(c => c.UserInfo)
           .WithRequiredPrincipal(c => c.Address).WillCascadeOnDelete(true);
            //一个用户可以有地址也可没有地址
            this.ToTable("Address");
        }
    }

    public class OtherInfoConfiguration : EntityTypeConfiguration<OtherInfo>
    {
        public OtherInfoConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Email).HasColumnName("Email");
            this.Property(c => c.Cell).HasColumnName("Cell");
            //Configuring a Required-to-Optional Relationship (One-to–Zero-or-One) 
            //一对零或一对一 ，一个用户可以有一个或没有其它信息（包括邮件地址、手机号等） 
            this.HasRequired(c => c.UserInfo)
                .WithOptional(c => c.OtherInfo).WillCascadeOnDelete(true);
            this.ToTable("OtherInfo");
        }
    }

    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Product_Name).HasColumnName("Product_Name");
            this.Property(c => c.Price).HasColumnName("Price");
            //商品不能包含订单，应该是订单包含商品...

            this.HasMany(c => c.Orders)
                .WithMany(c => c.Products);

            this.ToTable("Product");
        }
    }

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //one-to-many

            this.ToTable("Order");
        }
    }

}
