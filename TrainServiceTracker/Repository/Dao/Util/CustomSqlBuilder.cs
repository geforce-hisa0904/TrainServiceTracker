using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.github.geforce_hisa0904.TrainServiceTracker.Repository.Dao.Util
{
    internal class CustomSqlBuilder : SqlBuilder
    {
        public CustomSqlBuilder Insert(string column , object paramter)
        {
            AddClause("insert_column", $"'{column}'", null, ",", " (", ")", false);
            AddClause("insert_values", $"@{column}", new Dictionary<string, object> { [$"@{column}"] = paramter }, ", ", " VALUES (", ")", false);
            return this;
        }
        public CustomSqlBuilder Set(string sql, dynamic parameters = null)
        {
            AddClause("set", sql, parameters, " , ", "Set ", "\n", false);
            return this;
        }
    }
}
