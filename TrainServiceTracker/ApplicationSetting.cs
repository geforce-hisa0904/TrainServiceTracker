using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker
{
    internal class ApplicationSetting
    {
        public string GetConnectionSetting() => "Data Source=.\\mydb.db;Version=3;";
        public TimeSpan GetCommandTimeout() => TimeSpan.FromMinutes(1);

    }
}
