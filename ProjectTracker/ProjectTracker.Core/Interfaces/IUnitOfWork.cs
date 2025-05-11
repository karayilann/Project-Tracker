using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;
using Task = ProjectTracker.Core.Entities.Task;

namespace ProjectTracker.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Project> Projects { get; set; }
        IGenericRepository<User> Users { get; set; }
        IGenericRepository<Task> Tasks { get; set; }
        IGenericRepository<Role> Roles { get; set; }

    }
}
