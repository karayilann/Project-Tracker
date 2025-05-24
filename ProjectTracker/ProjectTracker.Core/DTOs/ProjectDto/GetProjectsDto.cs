using ProjectTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.DTOs.WorkItemDto;

namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class GetProjectsDto : BaseDto
    {
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public List<UserSimpleDto>? AssignedUsers { get; set; }
        public List<WorkItemSimpleDto>? WorkItems { get; set; }
    }
}
