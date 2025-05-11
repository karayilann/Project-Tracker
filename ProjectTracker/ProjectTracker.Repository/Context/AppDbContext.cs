using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Entities;

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
        
    }
}
