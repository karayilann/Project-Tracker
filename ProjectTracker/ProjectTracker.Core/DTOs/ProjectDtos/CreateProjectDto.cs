using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public List<int>? AssignedUserIds { get; set; }
        public List<WorkItem>? WorkItems { get; set; } = []; // Work Item dtosu yazılınca bunu da ekle
    }

}
