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
    public partial class PermissionConfiguration : EntityTypeConfiguration<Permission>
    {
        //权限
        public PermissionConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.PermissionName).HasMaxLength(50).IsRequired();
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.PermissionName).HasColumnName("PermissionName");
            this.Property(c => c.shot).IsRequired().HasColumnName("shot");
            this.Property(c => c.content).HasColumnName("content");
            
            this.ToTable("Permission");
        }
    }
}
