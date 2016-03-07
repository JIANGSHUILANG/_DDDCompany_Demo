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
    public partial class MenuConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.MenuName).HasMaxLength(100).IsRequired();
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.MenuName).HasMaxLength(100).IsRequired().HasColumnName("MenuName");
            this.Property(c => c.CreateTime).HasColumnName("CreateTime");
            this.Property(c => c.DelFlag).HasColumnName("DelFlag");
            this.Property(c => c.Remark).HasColumnName("Remark");
            this.Property(c => c.UpdateTime).HasColumnName("UpdateTime");
            this.Property(c => c.content).HasColumnName("content");
            this.Property(c => c.shot).HasColumnName("shot");
            this.Property(c => c.Url).HasColumnName("Url");

            //配置一对多
            this.HasMany(c => c.MenuChildens)
                .WithRequired(c => c.Menu);

            this.ToTable("Menu");
        }
    }
}
