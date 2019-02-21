using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Service
{
    internal interface IStatusContainer
    {
        IStatus GetLatestStatus(TypeTrain type);
        void UpdateLatestStatus(TypeTrain type, IStatus status);
    }
}
