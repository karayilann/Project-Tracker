using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.DTOs.UserDtos
{
    using ProjectTracker.Core.DTOs.RoleDto;

    public class UserDto : BaseDto
    {
        public string Surname { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; }
        public RoleDto? Role { get; set; }
    }
}
