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
            this.Property(c => c.content).HasColumnName("content");
            this.Property(c => c.shot).HasColumnName("shot");

            this.HasMany(c => c.UserInfos)
                .WithMany(c => c.Roles);

            this.HasMany(c => c.ActionInfos)
                .WithMany(c => c.Roles);

            this.HasMany(c => c.Menus)
                .WithMany(c => c.Roles);

            this.ToTable("Role");
        }
    }
}
