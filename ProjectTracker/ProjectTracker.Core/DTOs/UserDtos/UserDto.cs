using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.DTOs.UserDtos
{
    using ProjectDtos;

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; }
        public List<GetProjectsDto> Projects { get; set; }
        public List<WorkItem> WorkItems { get; set; }
    }
}
