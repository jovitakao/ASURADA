using ASURADA.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASURADA.Test
{
    [TestClass]
    public class MySqlRunSqlTest
    {
        //test database: https://www.mysqltutorial.org/getting-started-with-mysql/mysql-sample-database-aspx/
        private const string ConnectionString = "Server=127.0.0.1;Port=3306;Database=classicmodels; User Id=root;Password=tonyqus;";
        DataSourceInfo dsi = new DataSourceInfo();
        [TestInitialize]
        public void Setup()
        {
            dsi.DataSourceType = "mysql";
            dsi.ConnectionString = ConnectionString;
        }
        [TestMethod]
        public async Task TestListRows()
        {
            IDatabase db = DatabaseFactory.Create(dsi);
            var result=await db.RunSQL("select * from customers");

            Assert.IsNull(result.ErrorMessage); 
            Assert.AreEqual(122, result.Data.Count);
            Assert.AreEqual(13, result.Data[0].Length);
            Assert.IsTrue(result.QueryElapsedTime < 1000);
        }

        [TestMethod]
        public async Task TestSomeErrorMessage()
        {
            IDatabase db = DatabaseFactory.Create(dsi);
            var result = await db.RunSQL("select * from custom");

            Assert.AreEqual("Table 'classicmodels.custom' doesn't exist", result.ErrorMessage);

            result = await db.RunSQL("show x");

            Assert.IsTrue(result.ErrorMessage.StartsWith("You have an error in your SQL syntax;"));
        }
    }
}
