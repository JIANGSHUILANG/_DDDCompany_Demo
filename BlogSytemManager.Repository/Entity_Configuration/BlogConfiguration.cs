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
    public partial class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            this.HasKey(c => c.ID);
            this.Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Title).IsRequired().HasColumnName("Title");
            this.Property(c => c.Content).IsRequired().HasColumnName("Content");
            this.Property(c => c.BType).HasColumnName("BType");
            this.Property(c => c.CreateTime).HasColumnName("CreateTime");
            this.Property(c => c.Recommend).HasColumnName("Recommend");
            this.Property(c => c.BlogUrl).HasColumnName("BlogUrl");
            this.Property(c => c.Times).HasColumnName("Times");
            this.Property(c => c.Support).HasColumnName("Support");
            this.Property(c => c.Oppose).HasColumnName("Oppose");
            this.Property(c => c.Approach).HasColumnName("Approach");
            this.Property(c => c.Short).HasColumnName("Short");
            this.Property(c => c.Other).HasColumnName("Other");

            this.ToTable("Blog");
        }
    }
}
