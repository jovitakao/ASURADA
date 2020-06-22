using ASURADA.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ASURADA.Test
{
    [TestClass]
    public class MySqlDataSourceTest
    {
        private const string ConnectionString = "Server=127.0.0.1;Port=3306;Uid=root;Pwd=tonyqus;";
        DataSourceInfo dsi = new DataSourceInfo();
        [TestInitialize]
        public void Setup()
        {
            dsi.DataSourceType = "mysql";
            dsi.ConnectionString = ConnectionString;
        }

        [TestMethod]
        public async Task TestGetDatabases_NoFilter()
        {
            IDataSource ds=DataSourceFactory.Create(dsi);
            var databases = await ds.GetDatabases("*");
            Assert.IsTrue(databases.Count > 0);
            CollectionAssert.Contains(databases,"mysql");

            var databases2 = await ds.GetDatabases("   ");
            CollectionAssert.AreEqual(databases,databases2); 
        }

        [TestMethod]
        public async Task TestGetDatabases_Filter_ExactMatch()
        {
            IDataSource ds = DataSourceFactory.Create(dsi);
            var databases = await ds.GetDatabases("mysql");
            Assert.AreEqual(1,databases.Count);
            CollectionAssert.Contains(databases, "mysql");
        }

        [TestMethod]
        public async Task TestGetDatabases_Filter_NoMatch()
        {
            IDataSource ds = DataSourceFactory.Create(dsi);
            var databases = await ds.GetDatabases("≤ªø…ƒ‹∆•≈‰");
            Assert.AreEqual(0, databases.Count);
        }
        [TestMethod]
        public async Task TestGetDatabases_Filter_PartialMatch()
        {
            IDataSource ds = DataSourceFactory.Create(dsi);

            var databases2 = await ds.GetDatabases("*_schema");
            Assert.AreEqual(2, databases2.Count);
            CollectionAssert.Contains(databases2, "information_schema");
            CollectionAssert.Contains(databases2, "performance_schema");
        }
    }
}

