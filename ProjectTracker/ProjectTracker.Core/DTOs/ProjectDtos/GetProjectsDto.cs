using ProjectTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.DTOs.ProjectDtos
{
    public class GetProjectsDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public List<GetProjectUserDto>? AssignedUsers { get; set; }
        public List<GetProjectWorkItemDto>? WorkItems { get; set; }
    }
}
