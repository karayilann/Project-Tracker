using ProjectTracker.Core.Enums;
namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        //public List<User>? AssignedUsers { get; set; }

    }
}
