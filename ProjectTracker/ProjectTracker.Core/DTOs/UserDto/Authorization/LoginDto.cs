using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Core.DTOs.UserDto.Authorization
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
    }
}
