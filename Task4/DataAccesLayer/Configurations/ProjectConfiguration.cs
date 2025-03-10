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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();

            builder.HasOne(p => p.Creator).WithMany(u => u.Projects).HasForeignKey(p => p.CreatorId);
            builder.HasOne(p => p.Category).WithMany(c => c.Projects).HasForeignKey(p => p.CategoryId);
        }
    }
}
