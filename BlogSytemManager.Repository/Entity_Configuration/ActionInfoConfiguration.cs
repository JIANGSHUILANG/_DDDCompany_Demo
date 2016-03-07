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
            this.Property(c => c.content).HasColumnName("content");
            this.Property(c => c.shot).HasColumnName("shot");
                
            //配置多对多
            this.HasMany(c => c.UserInfos)
                .WithMany(c => c.ActionInfos);

            this.HasMany(c => c.Roles)
                .WithMany(c => c.ActionInfos);

       

            this.ToTable("ActionInfo");
        }
    }
}
