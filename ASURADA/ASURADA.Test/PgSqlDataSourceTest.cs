using ASURADA.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ASURADA.Test
{
    [TestClass]
    public class PgSqlDataSourceTest
    {
        private const string ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=tonyqus;";

        [TestMethod]
        public async Task TestGetDatabases_NoFilter()
        {
            DataSourceInfo dsi = new DataSourceInfo();
            dsi.ConnectionString = ConnectionString;
            IDataSource ds=DataSourceFactory.Create(dsi);
            var databases = await ds.GetDatabases("*");
            Assert.IsTrue(databases.Count > 0);
            CollectionAssert.Contains(databases,"postgres");

            var databases2 = await ds.GetDatabases("   ");
            CollectionAssert.AreEqual(databases,databases2); 
        }

        [TestMethod]
        public async Task TestGetDatabases_Filter_ExactMatch()
        {
            DataSourceInfo dsi = new DataSourceInfo();
            dsi.ConnectionString = ConnectionString;
            IDataSource ds = DataSourceFactory.Create(dsi);
            var databases = await ds.GetDatabases("postgres");
            Assert.AreEqual(1,databases.Count);
            CollectionAssert.Contains(databases, "postgres");
        }

        [TestMethod]
        public async Task TestGetDatabases_Filter_NoMatch()
        {
            DataSourceInfo dsi = new DataSourceInfo();
            dsi.ConnectionString = ConnectionString;
            IDataSource ds = DataSourceFactory.Create(dsi);
            var databases = await ds.GetDatabases("²»¿ÉÄÜÆ¥Åä");
            Assert.AreEqual(0, databases.Count);
        }
        [TestMethod]
        public async Task TestGetDatabases_Filter_PartialMatch()
        {
            DataSourceInfo dsi = new DataSourceInfo();
            dsi.ConnectionString = ConnectionString;
            IDataSource ds = DataSourceFactory.Create(dsi);

            var databases = await ds.GetDatabases("post");
            Assert.AreEqual(0, databases.Count);
            var databases2 = await ds.GetDatabases("post*");
            Assert.IsTrue(databases2.Count>0);
            CollectionAssert.Contains(databases2, "postgres");
        }
    }
}
