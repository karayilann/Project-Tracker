using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTracker.Core.Enums
{
    public enum TaskStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        OnHold = 3,
        Cancelled = 4
    }
}
