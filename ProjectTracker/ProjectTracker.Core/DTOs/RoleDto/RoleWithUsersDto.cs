using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.UserDtos;

namespace ProjectTracker.Core.DTOs.RoleDto;

public class RoleWithUsersDto : BaseDto
{
    public List<UserSimpleDto>? AssignedUsers { get; set; } = new List<UserSimpleDto>();
}