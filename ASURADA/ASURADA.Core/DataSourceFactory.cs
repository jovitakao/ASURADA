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
            var datasource = new PgSqlDataSource(dataSourceInfo);
            return datasource;
        }
    }
}
