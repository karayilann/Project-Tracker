using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.UserDtos;
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

        public async Task<List<GetProjectsDto>> GetAllAsync()
        {
            var projects = await _unitOfWork.Projects.GetAllWithIncludesAsync(x => x.AssignedUsers, y => y.WorkItems);

            return projects.Select(p => new GetProjectsDto {
                ProjectId = p.Id,
                ProjectName = p.Name,
                ProjectDescription = p.Description,
                ProjectStatus = p.Status,
                InAppPrioritiy = p.InAppPrioritiy,
                AssignedUsers = p.AssignedUsers?.Select(u => new GetProjectUserDto
                {
                    UserId = u.Id,
                    Name = u.Name
                }).ToList()
                ,
                WorkItems = p.WorkItems?.Select(w => new GetProjectWorkItemDto
                {
                    Title = w.Name,
                    Description = w.Description,
                    WorkItemStatus = w.WorkItemStatus,
                    InAppPrioritiy = w.InAppPrioritiy,
                    AssignedUser = w.AssignedUser != null
                        ? new GetProjectUserDto
                        {
                            UserId = w.AssignedUser.Id,
                            Name = w.AssignedUser.Name
                        }
                        : null
                }).ToList()
                
            }).ToList();
        }


        public async Task<Project> GetByIdAsync(int id)
        {
            return await _unitOfWork.Projects.GetByIdAsync(id);
        }

        public async Task AddAsync(Project project, List<int> userIds)
        {
            List<User>? users;
            if (userIds?.Any() == true)
            {

                users = await _unitOfWork.Users.WhereAsync(u => userIds.Contains(u.Id));
            }
            else
            {
                users = new List<User>();
            }

            project.AssignedUsers = users;
            
            Console.WriteLine("User Count: " + users.Count);
            foreach (var user in users)
            {
                Console.WriteLine($"ID : {user.Id}  Adı : {user.Name}");
            }

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
    }
}
