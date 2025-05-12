using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Repository.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAMIROG\\MAMIROG;Initial Catalog=ProjectTrackerDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Project - User (many-to-many)
            modelBuilder.Entity<Project>()
                .HasMany(p => p.AssignedUsers)
                .WithMany(u => u.Projects)
                .UsingEntity(j => j.ToTable("ProjectUsers"));

            // Role - User (one-to-many)
            modelBuilder.Entity<Role>()
                .HasMany(r => r.AssignedUsers)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // WorkItem - Project (many-to-one)
            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.Project)
                .WithMany(p => p.WorkItems)
                .HasForeignKey(w => w.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // WorkItem - User (many-to-one)
            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.AssignedUser)
                .WithMany(u => u.WorkItems)
                .HasForeignKey(w => w.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed (This seeds are created on ChatGPT by me)
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Developer" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Ali", Surname = "Yılmaz", Mail = "ali@example.com", RoleId = 1 },
                new User { UserId = 2, Name = "Ayşe", Surname = "Demir", Mail = "ayse@example.com", RoleId = 2 }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    ProjectName = "Proje Takip Sistemi",
                    ProjectDescription = "Entity ilişkilerini test etmek için örnek proje",
                    ProjectStatus = ProjectStatus.InProgress,
                    InAppPrioritiy = InAppPriorities.High
                }
            );

            modelBuilder.Entity<WorkItem>().HasData(
                new WorkItem
                {
                    WorkItemId = 1,
                    Title = "API geliştirme",
                    Description = "ProjectController yazılacak",
                    ProjectId = 1,
                    AssignedUserId = 2,
                    WorkItemStatus = WorkItemStatus.InProgress,
                    InAppPrioritiy = InAppPriorities.Medium
                }
            );

            modelBuilder.Entity("ProjectUser").HasData(
                new { ProjectsProjectId = 1, AssignedUsersUserId = 1 },
                new { ProjectsProjectId = 1, AssignedUsersUserId = 2 }
            );
        }
    }
}
