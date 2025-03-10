using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).HasMaxLength(100).IsRequired();

            builder.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(с => с.UserId);
            builder.HasOne(c => c.Project).WithMany(p => p.Comments).HasForeignKey(c => c.ProjectId);
        }
    }
}
