using System.Linq.Expressions;
using ProjectTracker.Core.Interfaces.Services;
using ProjectTracker.Core.Interfaces.UnitOfWork;

namespace ProjectTracker.Service.Services.Project
{
    using Core.Entities;

    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var projects = await _unitOfWork.Projects.GetAllWithIncludesAsync(x => x.AssignedUsers, y => y.WorkItems);
            return projects;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _unitOfWork.Projects.GetByIdAsync(id);
        }

        public async Task AddAsync(Project project)
        {
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Projects.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.Projects.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<List<User>> GetUsersByIdsAsync(List<int> userIds)
        {
            if (userIds == null || !userIds.Any())
                return new List<User>();

            return await _unitOfWork.Users.WhereAsync(u => userIds.Contains(u.Id));
        }

        public async Task<List<Project>> WhereAsync(Expression<Func<Project, bool>> expression)
        {
            return await _unitOfWork.Projects.WhereAsync(expression);
        }

    }
}
