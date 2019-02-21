using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Func.TrainService.Line
{
    internal interface ILineTrainService
    {
        Task<string> GetStatusAsync();
    }
}
