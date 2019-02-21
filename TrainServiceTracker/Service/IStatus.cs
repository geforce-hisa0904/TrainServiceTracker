using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Service
{
    public interface IStatus
    {
        string Status { get; }
        DateTimeOffset LastUpdate { get; }
    }
}
