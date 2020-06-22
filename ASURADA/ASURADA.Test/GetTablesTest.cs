using ASURADA.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASURADA.Test
{
    [TestClass]
    public class GetTablesTest
    {
        public async Task GetTables(string connectionString, string datasourceType)
        {
            DataSourceInfo dsi = new DataSourceInfo();
            dsi.DataSourceType = datasourceType;
            dsi.ConnectionString = connectionString;
            IDatabase db = DatabaseFactory.Create(dsi);
            var tables = await db.GetTables("*");
            Assert.IsTrue(tables.Count > 0);
        }
        [TestMethod]
        public async Task TestPgSqlGetTables()
        {
            await GetTables("Server=127.0.0.1;Port=5432;User Id=postgres;Password=tonyqus;Database=aaa", "postgresql");
        }
        [TestMethod]
        public async Task TestMySqlGetTables()
        {
            await GetTables("Server=127.0.0.1;Port=3306;Uid=root;Pwd=tonyqus;Database=test", "mysql");
        }
    }
}
