using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Core.Entities
{
    public class Role : BaseEntity
    {
        public List<User>? AssignedUsers { get; set; } = new List<User>();
    }
}
