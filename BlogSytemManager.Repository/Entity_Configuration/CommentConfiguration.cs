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
    public partial class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {

            this.HasKey(c => c.ID);
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Content).IsRequired().HasColumnName("Content");
            this.Property(c => c.CommentName).HasColumnName("CommentName");
            this.Property(c => c.CommentHeadUrl).HasColumnName("CommentHeadUrl");
            this.Property(c => c.Support).HasColumnName("Support");
            this.Property(c => c.Oppose).HasColumnName("Oppose");
            this.Property(c => c.CreateTime).HasColumnName("CreateTime");

            this.ToTable("Comment");
        }
    }
}
