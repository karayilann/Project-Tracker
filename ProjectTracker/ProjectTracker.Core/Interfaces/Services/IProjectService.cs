using System.Linq.Expressions;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Services
{
    public interface IProjectService : IService<Project>
    {
        Task<List<User>> GetUsersByIdsAsync(List<int> userIds);

    }
}
