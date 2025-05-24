using AutoMapper;
using ProjectTracker.Core.DTOs.ProjectDto;
using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.RoleDto;
using ProjectTracker.Core.DTOs.UserDto;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.DTOs.WorkItemDto;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();
            CreateMap<Project, GetProjectsDto>().ReverseMap();
            CreateMap<Project, WorkItemSimpleDto>().ReverseMap();
            CreateMap<Project, ProjectSimpleDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserSimpleDto>().ReverseMap();
            CreateMap<User, UserWithDetailsDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<WorkItem, CreateWorkItemDto>().ReverseMap();
            CreateMap<WorkItem, UpdateWorkItemDto>().ReverseMap();
            CreateMap<WorkItem, WorkItemSimpleDto>().ReverseMap();
            CreateMap<WorkItem, WorkItem>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();
            CreateMap<Role, RoleWithUsersDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();
        }
    }
}
