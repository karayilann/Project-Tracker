using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.DTOs.WorkItemDto
{
    public class WorkItemSimpleDto : BaseDto
    {
        public string Description { get; set; }
        public WorkItemStatus WorkItemStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
    }
}
