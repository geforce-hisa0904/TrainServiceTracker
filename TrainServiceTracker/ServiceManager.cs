using com.github.geforce_hisa0904.TrainServiceTracker.Func.Container;
using com.github.geforce_hisa0904.TrainServiceTracker.Func.TrainService;
using com.github.geforce_hisa0904.TrainServiceTracker.Repository.Dao;
using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker
{
    public static class ServiceManager
    {
        public static ITrainService GetTrainService()
        {
            var setting = new ApplicationSetting();
            return new TrainCoreService(new StatusCoreContainer(setting));
        }
    }
}
