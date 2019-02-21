using com.github.geforce_hisa0904.TrainServiceTracker;
using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            var test = ServiceManager.GetTrainService();
            var task = test.GetStatusAsync(TypeTrain.DenenToshiLine);
            task.Wait();
            var status = task.Result;
            LOGGER.Debug(status.Status);
            LOGGER.Debug("test");
        }
    }
}
