using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;
using Task = System.Threading.Tasks;

namespace ProjectTracker.Service.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GelAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task.Task AddAsync(Project project);
        Task.Task UpdateAsync(Project project);
        Task.Task DeleteAsync(Project project);

    }
}
