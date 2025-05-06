using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Core.Entities
{
    class Task
    {
        public int TaskID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public Project Project { get; set; }
        public User AssignedUser { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }
}
