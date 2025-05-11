using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces
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
