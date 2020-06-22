using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASURADA.Core.DataSources
{
    public class MySqlDataSource : IDataSource
    {
        public MySqlDataSource(DataSourceInfo dataSourceInfo)
        {
            ConnectionString = dataSourceInfo.ConnectionString;
        }
        public string ConnectionString { get; set; }
        public async Task<List<string>> GetDatabases(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                filter = "*";
            List<string> databases = new List<string>();

            filter = FilterUtility.ConvertSearchPatternToRegex(filter);

            using (var conn = new MySqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "show databases";
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var dbname = reader[0].ToString();
                        if (Regex.IsMatch(dbname, filter, RegexOptions.IgnoreCase))
                            databases.Add(dbname);
                    }
                }
            }
            return databases;
        }
    }
}
