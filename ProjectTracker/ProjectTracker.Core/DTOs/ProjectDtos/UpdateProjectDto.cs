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
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public InAppPriorities InAppPrioritiy { get; set; }
        public List<int>? AssignedUsers { get; set; }

    }
}
