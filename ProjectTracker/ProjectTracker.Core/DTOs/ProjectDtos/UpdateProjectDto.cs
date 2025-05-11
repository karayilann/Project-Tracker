using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class UpdateProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public List<int>? AssignedUsers { get; set; }

    }
}
