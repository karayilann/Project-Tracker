using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Services
{
    public interface IProjectService : IService<Project>
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project,List<int> userIds);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
    }
}
