using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Services;
using ProjectTracker.Core.Interfaces.UnitOfWork;

namespace ProjectTracker.Service.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<WorkItem>> GetAllAsync()
        {
            return await _unitOfWork.WorkItem.GetAllWithIncludesAsync(x=> x.AssignedUser, x=> x.Project);
        }

        public async Task<WorkItem?> GetByIdAsync(int id)
        {
            var items = await _unitOfWork.WorkItem.GetAllWithIncludesAsync(x => x.Project, x => x.AssignedUser);
            return items.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<WorkItem>> WhereAsync(Expression<Func<WorkItem, bool>> expression)
        {
            return await _unitOfWork.WorkItem.WhereAsync(expression);
        }

        public async Task AddAsync(WorkItem entity)
        {
            await _unitOfWork.WorkItem.AddAsync(entity);

            if (entity.AssignedUserId.HasValue)
            {
                var project = await _unitOfWork.Projects.GetByIdAsync(entity.ProjectId);
                var user = await _unitOfWork.Users.GetByIdAsync(entity.AssignedUserId.Value);

                if (project != null && user != null)
                {
                    project.AssignedUsers ??= new List<User>();
                    if (project.AssignedUsers.All(u => u.Id != user.Id))
                    {
                        project.AssignedUsers.Add(user);
                        _unitOfWork.Projects.Update(project);
                    }
                }
            }

            await _unitOfWork.SaveChangesAsync();
        }


        public async Task UpdateAsync(WorkItem entity)
        {
            _unitOfWork.WorkItem.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.WorkItem.GetByIdAsync(id);
            if (entity != null)
            {
                int? userId = entity.AssignedUserId;
                int projectId = entity.ProjectId;

                if (userId.HasValue)
                {
                    var otherWorkItems = await _unitOfWork.WorkItem.WhereAsync(w => w.ProjectId == projectId && w.AssignedUserId == userId && w.Id != id);

                    if (otherWorkItems == null || !otherWorkItems.Any())
                    {
                        var project = (await _unitOfWork.Projects
                                .GetAllWithIncludesAsync(p => p.AssignedUsers))
                            .FirstOrDefault(p => p.Id == projectId);

                        if (project != null && project.AssignedUsers != null)
                        {
                            var userToRemove = project.AssignedUsers.FirstOrDefault(u => u.Id == userId.Value);
                            if (userToRemove != null)
                            {
                                project.AssignedUsers.Remove(userToRemove);
                                _unitOfWork.Projects.Update(project);
                                await _unitOfWork.SaveChangesAsync();
                            }
                        }
                    }
                }
                _unitOfWork.WorkItem.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }


    }
}
