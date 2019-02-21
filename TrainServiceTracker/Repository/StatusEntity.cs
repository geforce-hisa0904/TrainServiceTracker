using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Repository
{
    internal class StatusEntity
    {
        public TypeTrain LineType { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }
    }
}
