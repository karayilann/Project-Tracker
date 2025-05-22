using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Repository.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);


            // Project - User (many-to-many)
            builder.HasMany(p => p.AssignedUsers)
                .WithMany(u => u.Projects)
                .UsingEntity(j => j.ToTable("ProjectUsers"));

        }
    }
}
