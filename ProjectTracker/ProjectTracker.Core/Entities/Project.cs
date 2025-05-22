using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.Entities
{
    public class Project : BaseEntity
    {
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public InAppPriorities InAppPrioritiy{ get; set; }
        public List<User>? AssignedUsers { get; set; } = new List<User>();
        public List<WorkItem>? WorkItems { get; set; } = new List<WorkItem>();
    }
}
