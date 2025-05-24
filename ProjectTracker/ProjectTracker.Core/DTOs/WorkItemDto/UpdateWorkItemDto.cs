using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.DTOs.WorkItemDto;

public class UpdateWorkItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public WorkItemStatus WorkItemStatus { get; set; }
    public InAppPriorities InAppPrioritiy { get; set; }
    public int ProjectId { get; set; }
    public int AssignedUserId { get; set; }
}