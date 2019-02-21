using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Service
{
    public  interface ITrainService
    {
        Task<TrainStatus> GetStatusAsync(TypeTrain type);
    }
}
