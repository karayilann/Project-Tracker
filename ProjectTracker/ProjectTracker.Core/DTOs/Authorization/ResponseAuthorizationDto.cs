using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.DTOs.UserDtos;

namespace ProjectTracker.Core.DTOs.Authorization
{
    public class ResponseAuthorizationDto
    {
        public string Token { get; set; }
        public UserSimpleDto User { get; set; }
    }
}
