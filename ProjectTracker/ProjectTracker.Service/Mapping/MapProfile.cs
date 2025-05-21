using AutoMapper;
using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Service.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();
            CreateMap<Project, GetProjectsDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
