using ProjectTracker.Core.DTOs.ProjectDto;
using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.DTOs.WorkItemDto;

public class WorkItemDto : BaseDto
{
    public string Description { get; set; }
    public WorkItemStatus WorkItemStatus { get; set; }
    public InAppPriorities InAppPrioritiy { get; set; }
    public int ProjectId { get; set; }
    public int AssignedUserId { get; set; }
    public ProjectSimpleDto? Project { get; set; }
    public UserSimpleDto? AssignedUser { get; set; }
}