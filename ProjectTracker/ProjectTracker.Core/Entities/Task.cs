using ProjectTracker.Core.Enums;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Core.Entities
{
    public class Task
    {
        public int TaskID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public Project Project { get; set; }
        public User AssignedUser { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }

    }
}
