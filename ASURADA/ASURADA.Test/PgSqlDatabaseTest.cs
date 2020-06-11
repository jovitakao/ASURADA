using ASURADA.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASURADA.Test
{
    [TestClass]
    public class PgSqlDatabaseTest
    {
        private const string ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=tonyqus;Database=aaa";
        [TestMethod]
        public async Task TestGetTables()
        {
            DataSourceInfo dsi = new DataSourceInfo();
            dsi.ConnectionString = ConnectionString;
            IDatabase db = DatabaseFactory.Create(dsi);
            var tables=await db.GetTables("*");
            Assert.IsTrue(tables.Count>0);
        }
    }
}
