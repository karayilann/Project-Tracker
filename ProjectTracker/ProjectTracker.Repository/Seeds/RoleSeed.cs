using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Repository.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData
            (
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Developer" },
                new Role { Id = 3, Name = "Project Manager" },
                new Role { Id = 4, Name = "Tester" },
                new Role { Id = 5, Name = "User" },
                new Role { Id = 6, Name = "Guest" }
            );
        }
    }
}
