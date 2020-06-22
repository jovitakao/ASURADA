using ASURADA.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASURADA.Test
{
    [TestClass]
    public class PgSqlRunSqlTest
    {
        private const string ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=tonyqus;Database=aaa";
        DataSourceInfo dsi = new DataSourceInfo();
        [TestInitialize]
        public void Setup()
        {
            dsi.DataSourceType = "pgsql";
            dsi.ConnectionString = ConnectionString;
        }
        [TestMethod]
        public async Task TestListRows()
        {
            IDatabase db = DatabaseFactory.Create(dsi);
            var result=await db.RunSQL("select * from departments");

            Assert.IsNull(result.ErrorMessage); 
            Assert.AreEqual(9, result.Data.Count);
            Assert.AreEqual(2, result.Data[0].Length);
            Assert.IsTrue(result.QueryElapsedTime < 1000);
        }

        [TestMethod]
        public async Task TestSomeErrorMessage()
        {
            IDatabase db = DatabaseFactory.Create(dsi);
            var result = await db.RunSQL("select * from custom");

            Assert.IsTrue(result.ErrorMessage.StartsWith("42P01"));

            result = await db.RunSQL("show x");

            Assert.IsTrue(result.ErrorMessage.StartsWith("42704"));
        }
    }
}
