using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Repository.Dao
{
    internal class StatusEntityMap : EntityMap<StatusEntity>
    {
        public StatusEntityMap()
        {
            Map(e => e.Status).ToColumn("status");
            Map(e => e.LastUpdate).ToColumn("last_update");
        }
    }
}
