using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.DTOs.Authorization;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Service.Authorization.Abstract
{
    public interface IJwtAuthentication
    {
        string GenerateToken(User user);
    }
}
