using com.github.geforce_hisa0904.TrainServiceTracker.Func.TrainService.Line;
using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Func.TrainService
{
    internal class TrainCoreService : ITrainService
    {
        private readonly IStatusContainer _container;
        public TrainCoreService(IStatusContainer container)
        {
            _container = container;
        }
        public async Task<TrainStatus> GetStatusAsync(TypeTrain type)
        {
            var st = _container.GetLatestStatus(type);
            ILineTrainService service = type.GetLineTrainService();
            var status = await service.GetStatusAsync();
            //TODO:状態保管するしくみを作成
            var tstatus =  new TrainStatus(status, DateTimeOffset.Now, true); ;

            _container.UpdateLatestStatus(type, tstatus);

            return tstatus;
        }
    }
}
