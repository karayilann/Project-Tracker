using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Repositories;

namespace ProjectTracker.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Project> Projects { get; set; }
        IGenericRepository<User> Users { get; set; }
        IGenericRepository<WorkItem> WorkItem { get; set; }
        IGenericRepository<Role> Roles { get; set; }
        Task<int> SaveChangesAsync();
    }
}
