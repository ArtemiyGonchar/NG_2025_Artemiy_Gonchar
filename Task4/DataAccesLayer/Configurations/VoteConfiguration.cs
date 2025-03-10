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
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasOne(v => v.Project).WithMany(p => p.Votes).HasForeignKey(v => v.ProjectId);
            builder.HasOne(v => v.User).WithMany(u => u.Votes).HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
