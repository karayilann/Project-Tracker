using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.Entities
{
    public class WorkItem : BaseEntity
    {
        public string Description { get; set; }
        public Project? Project { get; set; }
        public User? AssignedUser { get; set; }
        public WorkItemStatus WorkItemStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public int ProjectId { get; set; }
        public int AssignedUserId { get; set; }
    }
}
