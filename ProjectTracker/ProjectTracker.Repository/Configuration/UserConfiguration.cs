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
    public class UserConfiguration  : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            
            builder.Property(x => x.Mail)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasMany(x => x.WorkItems)
                .WithOne(w => w.AssignedUser)
                .HasForeignKey(w => w.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(z => z.Projects);

        }
    }
}
