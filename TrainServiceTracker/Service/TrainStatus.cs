using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Service
{
    public class TrainStatus : IStatus
    {
        public string Status { get; private set; }
        public DateTimeOffset LastUpdate { get; private set; }
        public bool IsChange { get; private set; }
        public TrainStatus(string status, DateTimeOffset lastUpdate, bool isChange)
        {
            Status = status;
            LastUpdate = lastUpdate;
            IsChange = isChange;
        }
    }
}
