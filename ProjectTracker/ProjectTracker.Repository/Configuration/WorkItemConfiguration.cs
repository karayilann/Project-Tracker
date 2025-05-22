using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Repository.Configuration
{
    public class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).UseIdentityColumn();
            builder.Property(w => w.ProjectId).IsRequired().HasMaxLength(100);

            // WI - Project (many-to-one)
            builder.HasOne(w => w.Project)
                .WithMany(p => p.WorkItems)
                .HasForeignKey(w => w.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // WI - User (many-to-one)
            builder.HasOne(w => w.AssignedUser)
                .WithMany(u => u.WorkItems)
                .HasForeignKey(w => w.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
