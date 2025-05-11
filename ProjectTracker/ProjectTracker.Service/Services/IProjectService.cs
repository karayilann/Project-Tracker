using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Service.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GelAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project);

    }
}
