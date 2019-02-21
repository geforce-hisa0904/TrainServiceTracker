using com.github.geforce_hisa0904.TrainServiceTracker.Func.TrainService.Line;
using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Func.TrainService
{
    internal static class TypeTrainExtentions
    {
        private static readonly IReadOnlyDictionary<TypeTrain, ILineTrainService> SERVICES = new Dictionary<TypeTrain, ILineTrainService>()
        {
            [TypeTrain.DenenToshiLine] = new DenenToshiLineTrainService()
        };

        public static ILineTrainService GetLineTrainService(this TypeTrain type)
        {
            return SERVICES[type];
        }
    }
}
