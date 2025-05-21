using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Service.Services
{
    public interface IProjectService
    {
        Task<List<GetProjectsDto>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project,List<int> userIds);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);

    }
}
