using com.github.geforce_hisa0904.TrainServiceTracker.Repository;
using com.github.geforce_hisa0904.TrainServiceTracker.Repository.Dao;
using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Func.Container
{
    internal class StatusCoreContainer : IStatusContainer
    {
        private readonly StatusDao _dao;
        public StatusCoreContainer(ApplicationSetting setting)
        {
            _dao = new StatusDao(setting);
        }
        public IStatus GetLatestStatus(TypeTrain type)
        {
            var entity = _dao.GetLatestStatus(type);
            return entity == null ? null : new StatusImpl(entity.Status, DateTime.SpecifyKind(entity.LastUpdate, DateTimeKind.Utc));
        }

        public void UpdateLatestStatus(TypeTrain type, IStatus status)
        {
            var entity = new StatusEntity() { LineType = type, Status = status.Status, LastUpdate = status.LastUpdate.UtcDateTime };
            _dao.Upsert(entity);
        }

        private class StatusImpl : IStatus
        {
            public string Status { get; private set; }
            public DateTimeOffset LastUpdate { get; private set; }
            public StatusImpl(string status, DateTimeOffset lastUpdate)
            {
                Status = status;
                LastUpdate = lastUpdate;
            }
        }
    }
}
