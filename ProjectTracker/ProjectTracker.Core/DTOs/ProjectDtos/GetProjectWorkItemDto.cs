using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class GetProjectWorkItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public GetProjectUserDto? AssignedUser { get; set; }
        public WorkItemStatus WorkItemStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }

    }
}
