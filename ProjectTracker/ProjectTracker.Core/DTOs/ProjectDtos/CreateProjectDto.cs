using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class CreateProjectDto
    {
        public string ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public List<int>? AssignedUserIds { get; set; }
        public List<WorkItem>? WorkItems { get; set; } = []; // Work Item dtosu yazılınca bunu da ekle
    }

}
