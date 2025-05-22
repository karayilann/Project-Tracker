using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Repository.Seeds
{
    public class WorkItemSeed : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            builder.HasData
            (

                new WorkItem
                {
                    Id = 1,
                    Name = "Kullanıcı Girişi",
                    Description = "Login ekranı yapılacak",
                    ProjectId = 1,
                    AssignedUserId = 2,
                    WorkItemStatus = WorkItemStatus.InProgress,
                    InAppPrioritiy = InAppPriorities.High
                },
                new WorkItem
                {
                    Id = 2,
                    Name = "Raporlama Modülü",
                    Description = "Raporlama eklenecek",
                    ProjectId = 1,
                    AssignedUserId = 3,
                    WorkItemStatus = WorkItemStatus.NotStarted,
                    InAppPrioritiy = InAppPriorities.Medium
                },
                new WorkItem
                {
                    Id = 3,
                    Name = "Müşteri Listesi",
                    Description = "Listeleme ekranı",
                    ProjectId = 2,
                    AssignedUserId = 4,
                    WorkItemStatus = WorkItemStatus.NotStarted,
                    InAppPrioritiy = InAppPriorities.Low
                },
                new WorkItem
                {
                    Id = 4,
                    Name = "API geliştirme",
                    Description = "ProjectController yazılacak",
                    ProjectId = 1,
                    AssignedUserId = 2,
                    WorkItemStatus = WorkItemStatus.InProgress,
                    InAppPrioritiy = InAppPriorities.Medium
                }
            );
        }
    }
}
