using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Repository.Dao
{
    internal static class TypeTrainExtentions
    {
        private static readonly IReadOnlyDictionary<TypeTrain, int> IDS = new Dictionary<TypeTrain, int>()
        {
            [TypeTrain.DenenToshiLine] = 1
        };
        public static int GetEntityId(this TypeTrain type)
        {
            return IDS[type];
        }
    }
}
