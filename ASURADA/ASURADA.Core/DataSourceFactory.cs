using ASURADA.Core.DataSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASURADA.Core
{
    public static class DataSourceFactory
    {
        public static IDataSource Create(DataSourceInfo dataSourceInfo)
        {
            var datasourceType=dataSourceInfo.DataSourceType.ToLower();
            if (datasourceType == "pgsql" || datasourceType=="postgresql")
            {
                var datasource = new PgSqlDataSource(dataSourceInfo);
                return datasource;
            }
            if (datasourceType == "mysql")
            {
                var datasource = new MySqlDataSource(dataSourceInfo);
                return datasource;
            }
            throw new NotSupportedException($"The database type '{dataSourceInfo.DataSourceType}' is not supported");
        }
    }
}
