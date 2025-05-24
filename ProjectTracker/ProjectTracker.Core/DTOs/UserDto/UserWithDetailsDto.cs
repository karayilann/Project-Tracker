using ProjectTracker.Core.DTOs.ProjectDto;
using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.WorkItemDto;

namespace ProjectTracker.Core.DTOs.UserDto
{
    using RoleDto;
    public class UserWithDetailsDto : BaseDto
    {
        public string Surname { get; set; }
        public string Mail { get; set; }
        public RoleDto? Role { get; set; }
        public List<WorkItemSimpleDto>? WorkItems { get; set; } = new List<WorkItemSimpleDto>();
        public List<ProjectSimpleDto>? Projects { get; set; } = new List<ProjectSimpleDto>();
    }
}
