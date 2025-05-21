using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Repository.Context;

namespace ProjectTracker.Service.Services
{
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
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectDescription = p.ProjectDescription,
                ProjectStatus = p.ProjectStatus,
                InAppPrioritiy = p.InAppPrioritiy,
                AssignedUsers = p.AssignedUsers?.Select(u => new GetProjectUserDto
                {
                    UserId = u.UserId,
                    Name = u.Name
                }).ToList()
                ,
                WorkItems = p.WorkItems?.Select(w => new GetProjectWorkItemDto
                {
                    Title = w.Title,
                    Description = w.Description,
                    WorkItemStatus = w.WorkItemStatus,
                    InAppPrioritiy = w.InAppPrioritiy,
                    AssignedUser = new GetProjectUserDto
                    {
                        UserId = w.AssignedUser.UserId,
                        Name = w.AssignedUser.Name
                    }
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

                users = await _unitOfWork.Users.WhereAsync(u => userIds.Contains(u.UserId));
            }
            else
            {
                users = new List<User>();
            }

            project.AssignedUsers = users;
            
            Console.WriteLine("User Count: " + users.Count);
            foreach (var user in users)
            {
                Console.WriteLine($"ID : {user.UserId}  Adı : {user.Name}");
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
