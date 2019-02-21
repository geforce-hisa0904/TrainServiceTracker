using com.github.geforce_hisa0904.TrainServiceTracker.Repository.Dao.Util;
using com.github.geforce_hisa0904.TrainServiceTracker.Service;
using Dapper;
using Dapper.FluentMap;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Repository.Dao
{
    internal class StatusDao
    {
        private static readonly string CREATE_TABLE = "CREATE TABLE IF NOT EXISTS T_Status (id int NOT NULL PRIMARY KEY, status text NOT NULL , last_update datetime NOT NULL)";
        private static readonly string SELECT_LATEST_TEMPLATE = "SELECT status , last_update FROM T_Status /**where**/";
        private static readonly string UPSERT_TEMPLATE = "INSERT OR REPLACE INTO T_Status /**insert_column**/ /**insert_values**/";

        private readonly ApplicationSetting _setting;
        private volatile object SYN_OBJ = new object();
        private bool _isInit = false;

        public StatusDao(ApplicationSetting setting) => _setting = setting;

        private void Init()
        {
            lock (SYN_OBJ)
            {
                if (_isInit)
                    return;

                FluentMapper.Initialize(config =>
                {
                    config.AddMap(new StatusEntityMap());
                });

                CreateTableIfNecessary();

                _isInit = true;
            }
        }
        private SQLiteConnection CreateConnection()
        {
            var con = new SQLiteConnection(_setting.GetConnectionSetting());
            con.Open();
            return con;
        }
        private void CreateTableIfNecessary()
        {
            using (SQLiteConnection con = CreateConnection())
            {
                con.Execute(sql:CREATE_TABLE,commandTimeout:_setting.GetCommandTimeout().Seconds);
            }
        }
        public StatusEntity GetLatestStatus(TypeTrain type)
        {
            Init();

            var builder = new CustomSqlBuilder();
            var template = builder.AddTemplate(SELECT_LATEST_TEMPLATE);

            var id = type.GetEntityId();
            builder.Where($"ID = {nameof(id)}", new { id });

            using (SQLiteConnection con = CreateConnection())
            {
                return con.QueryFirstOrDefault<StatusEntity>(sql: template.RawSql, param: template.Parameters, commandTimeout: _setting.GetCommandTimeout().Seconds);
            }
        }

        public void Upsert(StatusEntity entity)
        {
            Init();

            var builder = new CustomSqlBuilder();
            var template = builder.AddTemplate(UPSERT_TEMPLATE);

            builder.Insert("id", entity.LineType.GetEntityId());
            builder.Insert("status", entity.Status);
            builder.Insert("last_update", entity.LastUpdate);

            using (SQLiteConnection con = CreateConnection())
            {
                var ss = template.RawSql;
                var para = (dynamic)template.Parameters;

                con.Execute(sql: template.RawSql, param: template.Parameters, commandTimeout: _setting.GetCommandTimeout().Seconds);
            }
        }
    }
}
