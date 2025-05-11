using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.Entities
{
    public class WorkItem
    {
        public int WorkItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Project? Project { get; set; }
        public User? AssignedUser { get; set; }
        public WorkItemStatus WorkItemStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }

    }
}
