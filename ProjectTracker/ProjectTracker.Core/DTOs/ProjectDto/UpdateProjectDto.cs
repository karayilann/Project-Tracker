using ProjectTracker.Core.Enums;
namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class UpdateProjectDto : BaseDto
    {
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public List<int>? AssignedUserIds { get; set; } = new List<int>();

    }
}
