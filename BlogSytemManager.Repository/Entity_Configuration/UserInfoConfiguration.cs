using BolgSytemManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.Repository.Entity_Configuration
{
    public partial class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.UserName).HasMaxLength(50).IsRequired();
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.UserName).HasColumnName("UserName");
            this.Property(c => c.UserPass).IsRequired().HasColumnName("UserPass");
            this.Property(c => c.RegTime).HasColumnName("RegTime");
            this.Property(c => c.Email).HasColumnName("Email");
            this.Property(c => c.status).HasColumnName("status");
            this.Property(c => c.cell).HasColumnName("cell");
            this.Property(c => c.address).HasColumnName("address");
            this.Property(c => c.city1).HasColumnName("city1");
            this.Property(c => c.city2).HasColumnName("city2");
            this.Property(c => c.city3).HasColumnName("city3");
            this.Property(c => c.content).HasColumnName("content");
            this.Property(c => c.shot).HasColumnName("shot");

            this.HasMany(c => c.Roles)
                .WithMany(c => c.UserInfos);

            this.HasMany(c => c.ActionInfos)
                .WithMany(c => c.UserInfos);

            this.HasMany(c => c.Menus)
               .WithMany(c => c.UserInfos);

            this.ToTable("UserInfo");
        }
    }
}
