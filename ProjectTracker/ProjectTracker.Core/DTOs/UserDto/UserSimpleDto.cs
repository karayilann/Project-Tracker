using ProjectTracker.Core.DTOs.ProjectDtos;

namespace ProjectTracker.Core.DTOs.UserDtos;

public class UserSimpleDto : BaseDto
{
    public string Surname { get; set; }
    public string Mail { get; set; }
}