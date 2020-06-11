using ASURADA.Core.Databases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASURADA.Core
{
    public static class DatabaseFactory
    {
        public static IDatabase Create(DataSourceInfo dataSourceInfo)
        {
            var database = new PgSqlDatabase(dataSourceInfo);
            return database;
        }
    }
}
