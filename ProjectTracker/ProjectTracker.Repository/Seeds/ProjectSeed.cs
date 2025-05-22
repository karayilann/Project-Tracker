using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Repository.Seeds
{
    public class ProjectSeed : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id = 1,
                    Name = "Project 1",
                    Description = "Description for project 1",
                    Status = ProjectStatus.InProgress,
                    InAppPrioritiy = InAppPriorities.Low
                },
                new Project
                {
                    Id = 2,
                    Name = "Project 2",
                    Description = "Description for project 2",
                    Status = ProjectStatus.NotStarted,
                    InAppPrioritiy = InAppPriorities.Medium
                },
                new Project
                {
                    Id = 3,
                    Name = "Proje Takip Sistemi",
                    Description = "Entity ilişkilerini test etmek için örnek proje",
                    Status = ProjectStatus.InProgress,
                    InAppPrioritiy = InAppPriorities.High
                },
                new Project
                {
                    Id = 4,
                    Name = "iş Yönetimi Sistemi",
                    Description = "Takip uygulaması",
                    Status = ProjectStatus.InProgress,
                    InAppPrioritiy = InAppPriorities.High
                },
                new Project
                {
                    Id = 5,
                    Name = "CRM Yazılımı",
                    Description = "Müşteri ilişkileri yönetimi",
                    Status = ProjectStatus.NotStarted,
                    InAppPrioritiy = InAppPriorities.Medium
                }
            );
        }
    }
}
